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

namespace Xecrets.Licensing.Abstractions
{
    /// <summary>
    /// The license status enumeration, naming the different states a license can be in.
    /// </summary>
    public enum LicenseStatus
    {
        /// <summary>
        /// No, or unknown, state. Should never be used.
        /// </summary>
        None = 0,

        /// <summary>
        /// It's a GPL build and subscription licensing is irrelevant.
        /// Splash blurb politely and concisely asks to get a subscription.
        /// </summary>
        Gpl = 1,

        /// <summary>
        /// It's a build requiring a license, but there is no subscription license at all.
        /// Splash blurb is longer and explains the specific situation.
        /// </summary>
        Unlicensed = 2,

        /// <summary>
        /// It's a build requiring a license, but the subscription license is not valid because the license has expired
        /// Splash blurb is longer and explains the specific situation.
        /// </summary>
        Expired = 3,

        /// <summary>
        /// It's a build requiring a license, and the subscription license is valid for this version.
        /// Splash blurb politely and concisely thanks for the contribution.
        /// </summary>
        Valid = 4,

        /// <summary>
        /// It's a build requiring a license, but the subscription while not expired is not valid for
        /// this software.
        /// Splash blurb is longer and explains the specific situation.
        /// </summary>
        Invalid = 5,
    }
}
