#region Coypright and License

/*
 * Xecrets Licensing - Copyright © 2022-2024, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 * 
 * Unless explicitly licensed in writing, this source code is the sole property of Axantum Software AB,
 * and may not be copied, distributed, sold, modified or otherwise used in any way.
*/

#endregion Coypright and License

using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation
{
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
}
