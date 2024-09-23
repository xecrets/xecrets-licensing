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

namespace Xecrets.Licensing.Abstractions;

/// <summary>
/// Handle build date and time and GPL test
/// </summary>
public interface IBuildUtc
{
    /// <summary>
    /// Return <see langword="true"/> if this is a debug build
    /// </summary>
    bool IsDebugBuild { get; }

    /// <summary>
    /// Return <see langword="true"/> if this is a beta build
    /// </summary>
    bool IsBetaBuild { get; }

    /// <summary>
    /// Return <see langword="true"/> if this is a GPL build
    /// </summary>
    bool IsGplBuild { get; }

    /// <summary>
    /// Return a string representation of the build time, or what should be considered the build time.
    /// </summary>
    string BuildUtcText { get; }
}
