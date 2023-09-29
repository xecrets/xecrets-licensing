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

namespace Xecrets.Licensing.Abstractions
{
    /// <summary>
    /// An interface for determining license expiration by whatever method is appropriate
    /// for the product.
    /// </summary>
    public interface ILicenseExpiration
    {
        /// <summary>
        /// Check if the license has expired
        /// </summary>
        /// <param name="expiresUtc">The date and time when it expires.</param>
        /// <returns><see langword="true"/> if the license is determined to have expired.</returns>
        bool IsExpired(DateTime expiresUtc);
    }
}
