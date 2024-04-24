#region Coypright and License

/*
 * Xecrets Licensing - Copyright © 2022-2024, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 * 
 * Unless explicitly licensed in writing, this source code is the sole property of Axantum Software AB,
 * and may not be copied, distributed, sold, modified or otherwise used in any way.
*/

#endregion Coypright and License

using System.Globalization;

namespace Xecrets.Licensing
{
    /// <summary>
    /// Utility extensions
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Convert a UTC string to a <see cref="DateTime"/> in UTC.
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <returns></returns>
        public static DateTime FromUtc(this string utcDateTime)
        {
            return DateTime.Parse(utcDateTime, CultureInfo.GetCultureInfo("en-US"), DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
        }

        /// <summary>
        /// Convert a UTC <see cref="DateTime"/> to a string in local format.
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <returns></returns>
        public static string ToLocal(this DateTime utcDateTime)
        {
            return utcDateTime.ToLocalTime().ToString("G", CultureInfo.CurrentUICulture);
        }

        /// <summary>
        /// Convert a UTC string to a local string.
        /// </summary>
        /// <param name="utcDateTime"></param>
        /// <returns></returns>
        public static string ToLocal(this string utcDateTime)
        {
            return utcDateTime.FromUtc().ToLocal();
        }
    }
}
