#region Copyright and License

/*
 * Xecrets Licensing - Copyright © 2022-2024, Svante Seleborg, All Rights Reserved.
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
/// <param name="publicKeys">The public keys to use to validate the license signature.</param>
/// <param name="validProducts">An enumeration of valid values for the claim, i.e. what products are valid.</param>
public class License(INewLocator newLocator, string issuer, string claim, IEnumerable<string> publicKeys, IEnumerable<string> validProducts) : ILicense
{
    private LicenseSubscription _subscription = LicenseSubscription.Empty;

    /// <inheritdoc/>
    public async Task LoadFromAsync(IEnumerable<string> licenseCandidates)
    {
        LicenseToken = await GetBestValidLicenseTokenAsync(licenseCandidates);
        _subscription = Subscription(LicenseToken);
    }

    /// <inheritdoc/>
    public async Task<string> GetBestValidLicenseTokenAsync(IEnumerable<string> candidates)
    {
        candidates = candidates.Where(c => newLocator.New<ILicenseCandidates>().IsCandidate(c));
        if (!candidates.Any())
        {
            return string.Empty;
        }

        List<string> validSignatureLicenses = [];

        foreach (string publicKey in publicKeys)
        {
            await ValidSignatureLicenses(publicKey, candidates, validSignatureLicenses);
        }

        if (validSignatureLicenses.Count == 0)
        {
            return string.Empty;
        }

        var handler = new JsonWebTokenHandler();
        return validSignatureLicenses.OrderByDescending(l => handler.ReadToken(l).ValidTo).First();
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

        return new LicenseSubscription(token.ValidTo, token.Audiences.First(), token.GetClaim(claim).Value);
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
    /// <param name="keyPem"></param>
    /// <param name="candidates"></param>
    /// <param name="validSignedLicenses"></param>
    /// <returns></returns>
    private async Task ValidSignatureLicenses(string keyPem, IEnumerable<string> candidates, List<string> validSignedLicenses)
    {
        JsonWebTokenHandler handler = new JsonWebTokenHandler();
        var testKey = ECDsa.Create();
        testKey.ImportFromPem(keyPem);

        foreach (string candidate in candidates)
        {
            string trimmedCandidate = candidate.Trim().ReplaceLineEndings(string.Empty);
            TokenValidationResult result = await handler.ValidateTokenAsync(trimmedCandidate, new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = issuer,
                IssuerSigningKey = new ECDsaSecurityKey(testKey),
                ValidAlgorithms = validAlgorithms,
                ValidateLifetime = false,
            });

            if (result.IsValid)
            {
                validSignedLicenses.Add(trimmedCandidate);
            }
        }
    }
}
