#region Copyright and License

/*
 * Xecrets Licensing - Copyright © 2022-2024, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 * 
 * Unless explicitly licensed in writing, this source code is the sole property of Axantum Software AB,
 * and may not be copied, distributed, sold, modified or otherwise used in any way.
*/

#endregion Copyright and License

using System.Globalization;

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation
{
    /// <summary>
    /// Create appropriate license message blurbs depending on the license situation.
    /// </summary>
    /// <remarks>
    /// Create an instance of the LicenseBlurb class, providing text templates. Where appropriate, use the following placeholders:
    /// Literal "\n" - will be replaced by the appropriate new line for the environment
    /// {licensee} - will be replaced by the licensee from the license.
    /// {expiration} - will be replaced by the license expiration in InvariantCulture formatting
    /// {product} - will be replaced by the product the license is valid for.
    /// /// </remarks>
    /// <param name="newLocator">A reference to a <see cref="INewLocator"/> to locate dependencies.</param>
    /// <param name="gplBlurb">A text template for a GPL license.</param>
    /// <param name="unlicensedBlurb">A text template for the case when there is no license.</param>
    /// <param name="expiredBlurb">A text template for the case when a previously valid license has expired.</param>
    /// <param name="licensedBlurb">A text template for the case when the license is valid.</param>
    /// <param name="invalidBlurb">A text template for the case when the license is not valid for this product.</param>
    public class LicenseBlurb(INewLocator newLocator, string gplBlurb, string unlicensedBlurb, string expiredBlurb, string licensedBlurb, string invalidBlurb)
    {

        /// <summary>
        /// Get the appropriate license blurb for the current license loaded via <see cref="ILicense"/>
        /// </summary>
        /// <returns>An appropriate string.</returns>
        public override string ToString() => ToString(newLocator.New<ILicense>().Status(), newLocator.New<ILicense>().Subscription());

        /// <summary>
        /// Get the appropriate license blurb for the provided <see cref="LicenseStatus"/> and <see cref="LicenseSubscription"/>
        /// </summary>
        /// <param name="status">The status</param>
        /// <param name="subscription">The subscription</param>
        /// <returns>An appropriate string.</returns>
        public virtual string ToString(LicenseStatus status, LicenseSubscription subscription) => GetBlurb(status, subscription);

        private string GetBlurb(LicenseStatus status, LicenseSubscription subscription)
        {
            return status switch
            {
                LicenseStatus.Gpl => FillLicenseInfo(subscription, gplBlurb),

                LicenseStatus.Unlicensed => FillLicenseInfo(subscription, unlicensedBlurb),

                LicenseStatus.Expired => FillLicenseInfo(subscription, expiredBlurb),

                LicenseStatus.Valid => FillLicenseInfo(subscription, licensedBlurb),

                LicenseStatus.Invalid => FillLicenseInfo(subscription, invalidBlurb),

                _ => throw new InvalidOperationException($"Unexpected {nameof(LicenseStatus)} value '{status}'."),
            };
        }

        private static string FillLicenseInfo(LicenseSubscription subscription, string text)
        {
            return text
                .Replace("{licensee}", subscription.Licensee)
                .Replace("{expiration}", subscription.ExpirationUtc.ToLocal())
                .Replace("{product}", subscription.Product)
                .Replace(@"\n", Environment.NewLine);
        }
    }
}
