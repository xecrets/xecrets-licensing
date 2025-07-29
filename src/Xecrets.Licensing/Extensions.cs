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

using System.Globalization;

namespace Xecrets.Licensing;

/// <summary>
/// The Xecrets.Licensing namespace contains a few useful extension methods in <see cref="Extensions"/> .
/// </summary>
internal static class NamespaceDoc { }

/// <summary>
/// Utility extensions
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Convert a culture invariant UTC string to a <see cref="DateTime"/> in UTC.
    /// </summary>
    /// <param name="utcDateTime"></param>
    /// <returns>A <see cref="System.DateTime"/> as a UTC date and time.</returns>
    public static DateTime FromUtc(this string utcDateTime)
    {
        return DateTime.Parse(utcDateTime, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
    }

    /// <summary>
    /// Convert a UTC <see cref="DateTime"/> to a local time string in current culture format.
    /// </summary>
    /// <param name="utcDateTime"></param>
    /// <returns>A string with the local time in current UI culture format.</returns>
    public static string ToLocal(this DateTime utcDateTime)
    {
        return utcDateTime.ToLocalTime().ToString("g", CultureInfo.CurrentCulture);
    }

    /// <summary>
    /// Convert a culture invariant UTC string to a local time string in current UI culture format.
    /// </summary>
    /// <param name="utcDateTime"></param>
    /// <returns>A string with the local time in current UI culture format.</returns>
    public static string ToLocal(this string utcDateTime)
    {
        return utcDateTime.FromUtc().ToLocal();
    }
}
