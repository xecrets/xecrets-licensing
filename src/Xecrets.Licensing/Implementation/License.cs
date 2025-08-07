#region Copyright and License

/*
 * Xecrets Licensing - Copyright © 2022-2025, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 *
 * Xecrets Licensing is free software: you can redistribute it and/or modify it under the terms of the GNU General
 * Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any
 * later version.
 *
 * Xecrets Licensing is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the
 * implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License for more
 * details.
 *
 * You should have received a copy of the GNU General Public License along with Xecrets Licensing.  If not, see
 * <https://www.gnu.org/licenses/>.
 *
 * The source repository can be found at https://github.com/xecrets/xecrets-licensing please go there for more
 * information, suggestions and contributions. You may also visit https://www.axantum.com for more information about the
 * author, or submit support requests at https://www.axantum.com/support .
*/

#endregion Copyright and License

using System.Security.Cryptography;

using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation;

/// <summary>
/// The Xecrets.Licensing.Implementation namespace contains various default implementations of the abstractions from
/// <see cref="Xecrets.Licensing.Abstractions"/>.
/// </summary>
internal static class NamespaceDoc { }

/// <inheritdoc/>
/// <summary>
/// Instantiate a license
/// </summary>
/// <param name="newLocator">The <see cref="INewLocator"/> to use.</param>
/// <param name="issuer">The issuer, an arbitrary string that should be in the license.</param>
/// <param name="claim">The claim, an arbitrary string that should be in the license.</param>
/// <param name="publicKeyPems">The public key pems to use to validate the license signature.</param>
/// <param name="validProducts">An enumeration of valid values for the claim, i.e. what products are valid.</param>
public class License(INewLocator newLocator, string issuer, string claim, IEnumerable<string> publicKeyPems, IEnumerable<string> validProducts) : ILicense
{
    private LicenseSubscription _subscription = LicenseSubscription.Empty;

    /// <inheritdoc/>
    public async Task LoadFromAsync(IEnumerable<string> licenseTokenCandidates)
    {
        LicenseToken = await GetBestValidLicenseTokenAsync(licenseTokenCandidates);
        _subscription = Subscription(LicenseToken);
    }

    /// <inheritdoc/>
    public async Task<string> GetBestValidLicenseTokenAsync(IEnumerable<string> licenseTokenCandidates)
    {
        licenseTokenCandidates = licenseTokenCandidates
            .Select(c => newLocator.New<ILicenseCandidates>().ExtractCandidate(c))
            .Where(c => c.Length > 0);

        if (!licenseTokenCandidates.Any())
        {
            return string.Empty;
        }

        List<string> validLicenseTokens = [];

        foreach (string publicKeyPem in publicKeyPems)
        {
            await ValidLicenseTokens(publicKeyPem, licenseTokenCandidates, validLicenseTokens);
        }

        if (validLicenseTokens.Count == 0)
        {
            return string.Empty;
        }

        var handler = new JsonWebTokenHandler();
        return validLicenseTokens.OrderByDescending(l => handler.ReadToken(l).ValidTo).First();
    }

    /// <inheritdoc/>
    public string LicenseToken { get; private set; } = string.Empty;

    private static readonly string[] validAlgorithms = ["ES256"];

    private bool IsExpired(LicenseSubscription licenseSubscription)
    {
        return newLocator.New<ILicenseExpiration>().IsExpired(licenseSubscription.ExpirationUtc);
    }

    /// <inheritdoc/>
    public LicenseSubscription Subscription()
    {
        return _subscription;
    }

    /// <inheritdoc/>
    public LicenseSubscription Subscription(string signedLicense)
    {
        signedLicense = signedLicense.Trim();
        if (signedLicense.Length == 0)
        {
            return LicenseSubscription.Empty;
        }

        var handler = new JsonWebTokenHandler();
        JsonWebToken token = (JsonWebToken)handler.ReadToken(signedLicense);

        LicenseType licenseType = GetLicenseType(token);
        return new LicenseSubscription(token.ValidTo, token.Audiences.First(), token.GetClaim(claim).Value, licenseType);
    }

    private static LicenseType GetLicenseType(JsonWebToken token)
    {
        string licenseTypeString = token.Claims.FirstOrDefault(c => c.Type == "type.axantum.com")?.Value ?? string.Empty;

        // Heuristic backwards compatibility handling for licenses issued w/o the type claim.
        if (licenseTypeString.Length == 0)
        {
            TimeSpan licenseValidityPeriod = token.ValidTo - token.ValidFrom;
            if (licenseValidityPeriod.Days < 7)
            {
                return LicenseType.FreeTest;
            }
            if (licenseValidityPeriod.Days < 21)
            {
                return LicenseType.Trial;
            }
            if (licenseValidityPeriod.Days < 300)
            {
                return LicenseType.Free;
            }
            return LicenseType.Paid;
        }

        return licenseTypeString switch
        {
            "free" => LicenseType.Free,
            "test" => LicenseType.FreeTest,
            "trial" => LicenseType.Trial,
            "paid" => LicenseType.Paid,
            _ => LicenseType.None,
        };
    }

    /// <inheritdoc/>
    public LicenseStatus Status() => Status(_subscription);

    /// <inheritdoc/>
    public LicenseStatus Status(LicenseSubscription subscription)
    {
        bool isGplBuild = newLocator.New<IBuildUtc>().IsGplBuild;

        if (!isGplBuild && subscription == LicenseSubscription.Empty)
        {
            return LicenseStatus.Unlicensed;
        }

        if (!isGplBuild && IsExpired(subscription))
        {
            return LicenseStatus.Expired;
        }

        if (validProducts.Contains(subscription.Product) && !IsExpired(subscription))
        {
            return LicenseStatus.Valid;
        }

        if (isGplBuild)
        {
            return LicenseStatus.Gpl;
        }

        return LicenseStatus.Invalid;
    }

    /// <summary>
    /// Get licenses with valid signatures. They may still be expired, or invalid for this product.
    /// </summary>
    /// <param name="publicKeyPem"></param>
    /// <param name="licenseTokenCandidates"></param>
    /// <param name="validLicenseTokens"></param>
    /// <returns></returns>
    private async Task ValidLicenseTokens(string publicKeyPem, IEnumerable<string> licenseTokenCandidates, List<string> validLicenseTokens)
    {
        JsonWebTokenHandler handler = new JsonWebTokenHandler();
        var ecdsa = ECDsa.Create();
        ecdsa.ImportFromPem(publicKeyPem);

        foreach (string tokenCandidate in licenseTokenCandidates)
        {
            TokenValidationResult result = await handler.ValidateTokenAsync(tokenCandidate, new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = issuer,
                IssuerSigningKey = new ECDsaSecurityKey(ecdsa),
                ValidAlgorithms = validAlgorithms,
                ValidateLifetime = false,
            });

            if (result.IsValid)
            {
                validLicenseTokens.Add(tokenCandidate);
            }
        }
    }
}
