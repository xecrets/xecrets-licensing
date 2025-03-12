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

namespace Xecrets.Licensing.Abstractions;

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
    /// <see cref="Xecrets.Licensing.Implementation.LicenseBlurb"/> politely and concisely asks to get a subscription.
    /// </summary>
    Gpl = 1,

    /// <summary>
    /// It's a build requiring a license, but there is no subscription license at all.
    /// <see cref="Xecrets.Licensing.Implementation.LicenseBlurb"/> is longer and explains the specific situation.
    /// </summary>
    Unlicensed = 2,

    /// <summary>
    /// It's a build requiring a license, but the subscription license is not valid because the license has expired
    /// <see cref="Xecrets.Licensing.Implementation.LicenseBlurb"/> is longer and explains the specific situation.
    /// </summary>
    Expired = 3,

    /// <summary>
    /// It's a build requiring a license, and the subscription license is valid for this version.
    /// <see cref="Xecrets.Licensing.Implementation.LicenseBlurb"/> politely and concisely thanks for the contribution.
    /// </summary>
    Valid = 4,

    /// <summary>
    /// It's a build requiring a license, but the subscription while not expired is not valid for this software. <see
    /// cref="Xecrets.Licensing.Implementation.LicenseBlurb"/> is longer and explains the specific situation.
    /// </summary>
    Invalid = 5,
}
