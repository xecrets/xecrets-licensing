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

using Xecrets.Licensing.Implementation;

namespace Xecrets.Licensing.Abstractions;

/// <summary>
/// The Xecrets.Licensing.Abstractions namespace contains the interfaces that are used to interact with the licensing
/// system. There are various implementations of these interfaces in the <see cref="Xecrets.Licensing.Implementation"/>
/// namespace, or you can roll your own for your specific needs.
/// </summary>
internal static class NamespaceDoc { }

/// <summary>
/// Select, validate and interpret the best available license
/// </summary>
public interface ILicense
{
    /// <summary>
    /// Load the best license from a list of candidates. What is the best license is determined by the implementation.
    /// If no license is found, the <see cref="LicenseToken"/> will be an empty string.
    /// </summary>
    /// <param name="licenseTokenCandidates">The list of license candidates.</param>
    /// <returns>A waitable <see cref="Task"/></returns>
    Task LoadFromAsync(IEnumerable<string> licenseTokenCandidates);

    /// <summary>
    /// Determine the best license from a list of candidates. What is the best license is determined by the
    /// implementation.
    /// </summary>
    /// <param name="licenseTokenCandidates">The list of license candidates.</param>
    /// <returns>The best license token string, or an empty string if no candidate was valid.</returns>
    Task<string> GetBestValidLicenseTokenAsync(IEnumerable<string> licenseTokenCandidates);

    /// <summary>
    /// The raw license token string that was loaded, <see cref="LoadFromAsync(IEnumerable{string})"/>, or an empty
    /// string.
    /// </summary>
    string LicenseToken { get; }

    /// <summary>
    /// The <see cref="LicenseSubscription"/> that was loaded, <see cref="LoadFromAsync(IEnumerable{string})"/> or
    /// <see cref="LicenseSubscription.Empty"/> .
    /// </summary>
    /// <returns>The <see cref="LicenseSubscription"/>.</returns>
    LicenseSubscription Subscription();

    /// <summary>
    /// A <see cref="LicenseSubscription"/> instantiated by interpreting a raw license token string
    /// </summary>
    /// <param name="licenseToken">The raw signed license token string, it's assumed it is a proper token</param>
    /// <returns>
    /// The <see cref="LicenseSubscription"/> or <see cref="LicenseSubscription.Empty"/> if the <paramref
    /// name="licenseToken"/> was an empty string.
    /// </returns>
    LicenseSubscription Subscription(string licenseToken);
    
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
