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
/// An <see cref="ILicenseExpiration"/> implementation comparing the license with date and time of the build.
/// </summary>
/// <remarks>
/// Instantiate an instance providing a locator
/// </remarks>
/// <param name="newLocator">The <see cref="INewLocator"/> to use to get dependencies.</param>
public class LicenseExpirationByBuildTime(INewLocator newLocator) : ILicenseExpiration
{
    /// <summary>
    /// Check if the license has expired, as determined by comparing the build time with the expiration time.
    /// The build time is determined by the <see cref="IBuildUtc"/> implementation.
    /// </summary>
    /// <param name="expiresUtc">The date and time when it expires.</param>
    /// <returns><see langword="true"/> if the license is determined to have expired.</returns>
    public bool IsExpired(DateTime expiresUtc)
    {
        string buildUtcText = newLocator.New<IBuildUtc>().BuildUtcText;
        DateTime buildUtc = buildUtcText.FromUtc();
        return expiresUtc < buildUtc;
    }
}
