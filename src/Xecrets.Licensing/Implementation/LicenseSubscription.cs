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

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation;

/// <summary>
/// The subscription, with an expiration, a licensee and valid for a product
/// </summary>
/// <remarks>
/// Instantiate a subscription
/// </remarks>
/// <param name="expirationUtc">The date and time of expiration.</param>
/// <param name="licensee">The licensee, an arbitrary string representing the holder of the license.</param>
/// <param name="product">The product that is licensed, an arbitrary string.</param>
/// <param name="licenseType">The type of license.</param>
public class LicenseSubscription(DateTime expirationUtc, string licensee, string product, LicenseType licenseType)
{
    /// <summary>
    /// An empty default subscription
    /// </summary>
    public static readonly LicenseSubscription Empty = new LicenseSubscription(DateTime.MinValue, string.Empty, string.Empty, LicenseType.None);

    /// <summary>
    /// The date and time of expiration.
    /// </summary>
    public DateTime ExpirationUtc { get; } = expirationUtc;

    /// <summary>
    /// The licensee, an arbitrary string representing the holder of the license.
    /// </summary>
    public string Licensee { get; } = licensee;

    /// <summary>
    /// The product that is licensed, an arbitrary string.
    /// </summary>
    public string Product { get; } = product;

    /// <summary>
    /// The type of license, free, trial, paid etc.
    /// </summary>
    public LicenseType LicenseType { get; } = licenseType;
}
