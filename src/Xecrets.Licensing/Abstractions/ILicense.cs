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

using Xecrets.Licensing.Implementation;

namespace Xecrets.Licensing.Abstractions
{
    /// <summary>
    /// Select, validate and interpret the best available license
    /// </summary>
    public interface ILicense
    {
        /// <summary>
        /// Load the best license from a list of candidates.
        /// </summary>
        /// <param name="licenseCandidates">The list of license candidates.</param>
        /// <returns>A waitable <see cref="Task"/></returns>
        Task LoadFromAsync(IEnumerable<string> licenseCandidates);

        /// <summary>
        /// Determine the best license from a list of candidates.
        /// </summary>
        /// <param name="candidates">The list of license candidates.</param>
        /// <returns>The best license token string, or an empty string</returns>
        Task<string> GetBestValidLicenseTokenAsync(IEnumerable<string> candidates);

        /// <summary>
        /// The raw license token string that was loaded, <see cref="LoadFromAsync(IEnumerable{string})"/>
        /// </summary>
        string LicenseToken { get; }

        /// <summary>
        /// The <see cref="LicenseSubscription"/> that was loaded, <see cref="LoadFromAsync(IEnumerable{string})"/>
        /// </summary>
        /// <returns></returns>
        LicenseSubscription Subscription();

        /// <summary>
        /// A <see cref="LicenseSubscription"/> instantiated by interpreting a raw license token string
        /// </summary>
        /// <param name="signedLicense">The raw signed license token string, it's assumed it is a proper token</param>
        /// <returns>The <see cref="LicenseSubscription"/> or an empty if the <paramref name="signedLicense"/> was an empty string.</returns>
        LicenseSubscription Subscription(string signedLicense);
        
        /// <summary>
        /// The <see cref="LicenseStatus"/> of the loaded license, <see cref="LoadFromAsync(IEnumerable{string})"/>
        /// </summary>
        /// <returns>The loaded <see cref="LicenseStatus"/>.</returns>
        LicenseStatus Status();

        /// <summary>
        /// A <see cref="LicenseStatus"/> from the <see cref="LicenseSubscription"/>
        /// </summary>
        /// <param name="subscription">A <see cref="LicenseSubscription"/></param>
        /// <returns>A <see cref="LicenseStatus"/></returns>
        LicenseStatus Status(LicenseSubscription subscription);
    }
}
