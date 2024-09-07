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

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation
{
    /// <summary>
    /// An <see cref="ILicenseExpiration"/> implementation comparing the license with the current date and time.
    /// </summary>
    public class LicenseExpirationByCurrentTime(TimeProvider timeProvider) : ILicenseExpiration
    {
        /// <inheritdoc/>
        public bool IsExpired(DateTime expiresUtc)
        {
            return expiresUtc < timeProvider.GetUtcNow().UtcDateTime;
        }
    }
}
