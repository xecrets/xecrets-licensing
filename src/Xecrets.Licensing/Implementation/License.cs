#region Coypright and License

/*
 * Xecrets Licensing - Copyright © 2022-2023, Svante Seleborg, All Rights Reserved.
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
    public class License : ILicense
    {
        private readonly string _issuer;

        private readonly string _claim;

        private readonly IEnumerable<string> _validProducts;

        private readonly INewLocator _newLocator;

        private readonly IEnumerable<string> _publicKeys;

        private LicenseSubscription _subscription = LicenseSubscription.Empty;

        /// <summary>
        /// Instantiate a license
        /// </summary>
        /// <param name="newLocator">The <see cref="INewLocator"/> to use.</param>
        /// <param name="issuer">The issuer, an arbitrary string that should be in the license.</param>
        /// <param name="claim">The claim, an arbitrary string that should be in the license.</param>
        /// <param name="publicKeys">The public keys to use to validate the license signature.</param>
        /// <param name="validProducts">An enumeration of valid values for the claim, i.e. what products are valid.</param>
        public License(INewLocator newLocator, string issuer, string claim, IEnumerable<string> publicKeys, IEnumerable<string> validProducts)
        {
            _issuer = issuer;
            _claim = claim;
            _newLocator = newLocator;
            _publicKeys = publicKeys;
            _validProducts = validProducts;
        }

        /// <inheritdoc/>
        public async Task LoadFromAsync(IEnumerable<string> licenseCandidates)
        {
            LicenseToken = await GetBestValidLicenseTokenAsync(licenseCandidates);
            _subscription = Subscription(LicenseToken);
        }

        /// <inheritdoc/>
        public async Task<string> GetBestValidLicenseTokenAsync(IEnumerable<string> candidates)
        {
            candidates = candidates.Where(c => _newLocator.New<ILicenseCandidates>().IsCandidate(c));
            if (!candidates.Any())
            {
                return string.Empty;
            }

            List<string> validSignedLicenses = new List<string>();

            foreach (string publicKey in _publicKeys)
            {
                await ValidSignedLicenses(publicKey, candidates, validSignedLicenses);
            }

            if (!validSignedLicenses.Any())
            {
                return string.Empty;
            }

            var handler = new JsonWebTokenHandler();
            return validSignedLicenses.OrderByDescending(l => handler.ReadToken(l).ValidTo).First();
        }

        /// <inheritdoc/>
        public string LicenseToken { get; private set; } = string.Empty;

        private bool IsExpired(LicenseSubscription licenseSubscription)
        {
                return _newLocator.New<ILicenseExpiration>().IsExpired(licenseSubscription.ExpirationUtc);
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

            return new LicenseSubscription(token.ValidTo, token.Audiences.First(), token.GetClaim(_claim).Value);
        }

        /// <inheritdoc/>
        public LicenseStatus Status() => Status(_subscription);

        /// <inheritdoc/>
        [SuppressMessage("Style", "IDE0046:Convert to conditional expression", Justification = "Not a good choice for a long chain of conditionals.")]
        public LicenseStatus Status(LicenseSubscription subscription)
        {
            bool isGplBuild = _newLocator.New<IBuildUtc>().IsGplBuild;

            if (!isGplBuild && subscription == LicenseSubscription.Empty)
            {
                return LicenseStatus.Unlicensed;
            }

            if (!isGplBuild && IsExpired(subscription))
            {
                return LicenseStatus.Expired;
            }

            if (_validProducts.Contains(subscription.Product) && !IsExpired(subscription))
            {
                return LicenseStatus.Valid;
            }

            if (isGplBuild)
            {
                return LicenseStatus.Gpl;
            }

            return LicenseStatus.Invalid;
        }

        private async Task ValidSignedLicenses(string keyPem, IEnumerable<string> candidates, List<string> validSignedLicenses)
        {
            JsonWebTokenHandler handler = new JsonWebTokenHandler();
            var testKey = ECDsa.Create();
            testKey.ImportFromPem(keyPem);

            foreach (string candidate in candidates)
            {
                string trimmedCandidate = candidate.Trim();
                TokenValidationResult result = await handler.ValidateTokenAsync(trimmedCandidate, new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidIssuer = _issuer,
                    IssuerSigningKey = new ECDsaSecurityKey(testKey),
                    ValidAlgorithms = new string[] { "ES256" },
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
