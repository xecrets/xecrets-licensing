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

using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

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
    /// <returns>A string with the local time in current culture format.</returns>
    public static string ToLocal(this DateTime utcDateTime)
    {
        return BestEffortGeneralFormat(utcDateTime.ToLocalTime());
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

    /// <summary>
    /// Format a <see cref="DateTime"/> in a best effort general format in the case we're compiled without
    /// globalization support, which is determined by the current culture being invariant.
    /// </summary>
    /// <param name="dt">The DateTime to format</param>
    /// <returns>The formatted string as close as possible to "g" format.</returns>
    private static string BestEffortGeneralFormat(DateTime dt)
    {
        if (CultureInfo.CurrentCulture.Name.Length > 0)
        {
            return dt.ToString("g", CultureInfo.CurrentCulture);
        }

        string format = DefaultFormat;

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            format = WindowsFormat();
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            format = LinuxMacOsFormat();
        }

        return dt.ToString(format, CultureInfo.InvariantCulture);
    }

    [DynamicDependency("GetValue", typeof(Microsoft.Win32.Registry))]
    private static string WindowsFormat()
    {
        try
        {
            Type? registryType = Type.GetType("Microsoft.Win32.Registry, Microsoft.Win32.Registry");
            if (registryType == null)
            {
                return DefaultFormat;
            }

            MethodInfo? getValueMethod = registryType.GetMethod("GetValue", [typeof(string), typeof(string), typeof(object)]);
            if (getValueMethod == null)
            {
                return DefaultFormat;
            }

            string? dateFormat = getValueMethod.Invoke(null, [@"HKEY_CURRENT_USER\Control Panel\International", "sShortDate", null]) as string;
            string? timeFormat = getValueMethod.Invoke(null, [@"HKEY_CURRENT_USER\Control Panel\International", "sShortTime", null]) as string;

            if (!string.IsNullOrEmpty(dateFormat) && !string.IsNullOrEmpty(timeFormat))
            {
                return $"{dateFormat} {timeFormat}";
            }
        }
        catch
        {
        }

        return DefaultFormat;
    }

    private static string LinuxMacOsFormat()
    {
        string? locale;

        locale = Environment.GetEnvironmentVariable("LC_ALL");
        if (string.IsNullOrEmpty(locale))
        {
            locale = Environment.GetEnvironmentVariable("LC_TIME");
        }
        if (string.IsNullOrEmpty(locale))
        {
            locale = Environment.GetEnvironmentVariable("LANG");
        }
        if (string.IsNullOrEmpty(locale))
        {
            locale = "en_US"; // Fallback to a default locale
        }

        string cultureName = locale.Replace('_', '-').Split('.')[0].Trim();
        return GetShortDateTimeFormat(cultureName);
    }

    // Dictionary: culture name => "g" format string (short date + short time)
    // Source: .NET 8 CultureInfo.DateTimeFormat.ShortDatePattern + " " + ShortTimePattern
    // All cultures in .NET 8 as of July 2025.
    private static readonly Dictionary<string, string> ShortDateTimeFormats = new(StringComparer.OrdinalIgnoreCase)
    {
        { "af-ZA", "yyyy/MM/dd HH:mm" },
        { "am-ET", "d/M/yyyy h:mm tt" },
        { "ar-AE", "dd/MM/yyyy h:mm tt" },
        { "ar-BH", "dd/MM/yyyy h:mm tt" },
        { "ar-DZ", "dd-MM-yyyy HH:mm" },
        { "ar-EG", "dd/MM/yyyy h:mm tt" },
        { "ar-IQ", "dd/MM/yyyy h:mm tt" },
        { "ar-JO", "dd/MM/yyyy h:mm tt" },
        { "ar-KW", "dd/MM/yyyy h:mm tt" },
        { "ar-LB", "dd/MM/yyyy h:mm tt" },
        { "ar-LY", "dd/MM/yyyy h:mm tt" },
        { "ar-MA", "dd-MM-yyyy HH:mm" },
        { "ar-OM", "dd/MM/yyyy h:mm tt" },
        { "ar-QA", "dd/MM/yyyy h:mm tt" },
        { "ar-SA", "dd/MM/yy h:mm tt" },
        { "ar-SY", "dd/MM/yyyy h:mm tt" },
        { "ar-TN", "dd-MM-yyyy HH:mm" },
        { "ar-YE", "dd/MM/yyyy h:mm tt" },
        { "arn-CL", "dd-MM-yyyy HH:mm" },
        { "as-IN", "dd-MM-yyyy h:mm tt" },
        { "az-Cyrl-AZ", "dd.MM.yyyy HH:mm" },
        { "az-Latn-AZ", "dd.MM.yyyy HH:mm" },
        { "ba-RU", "dd.MM.yyyy HH:mm" },
        { "be-BY", "dd.MM.yyyy HH:mm" },
        { "bg-BG", "d.M.yyyy HH:mm" },
        { "bn-BD", "dd-MM-yy h:mm tt" },
        { "bn-IN", "dd-MM-yy h:mm tt" },
        { "bo-CN", "yyyy/M/d H:mm" },
        { "br-FR", "dd/MM/yyyy HH:mm" },
        { "bs-Cyrl-BA", "d.M.yyyy. HH:mm" },
        { "bs-Latn-BA", "d.M.yyyy. HH:mm" },
        { "ca-ES", "dd/MM/yyyy H:mm" },
        { "co-FR", "dd/MM/yyyy HH:mm" },
        { "cs-CZ", "d.M.yyyy H:mm" },
        { "cy-GB", "dd/MM/yyyy HH:mm" },
        { "da-DK", "dd-MM-yyyy HH:mm" },
        { "de-AT", "dd.MM.yyyy HH:mm" },
        { "de-CH", "dd.MM.yyyy HH:mm" },
        { "de-DE", "dd.MM.yyyy HH:mm" },
        { "de-LI", "dd.MM.yyyy HH:mm" },
        { "de-LU", "dd.MM.yyyy HH:mm" },
        { "dsb-DE", "d. M. yyyy HH:mm" },
        { "dv-MV", "dd/MM/yy HH:mm" },
        { "el-GR", "d/M/yyyy h:mm tt" },
        { "en-029", "MM/dd/yyyy h:mm tt" },
        { "en-AU", "d/MM/yyyy h:mm tt" },
        { "en-BZ", "dd/MM/yyyy h:mm tt" },
        { "en-CA", "yyyy-MM-dd h:mm tt" },
        { "en-GB", "dd/MM/yyyy HH:mm" },
        { "en-IE", "dd/MM/yyyy HH:mm" },
        { "en-IN", "dd-MM-yyyy h:mm tt" },
        { "en-JM", "dd/MM/yyyy h:mm tt" },
        { "en-MY", "d/M/yyyy h:mm tt" },
        { "en-NZ", "d/MM/yyyy h:mm tt" },
        { "en-PH", "M/d/yyyy h:mm tt" },
        { "en-SG", "d/M/yyyy h:mm tt" },
        { "en-TT", "dd/MM/yyyy h:mm tt" },
        { "en-US", "M/d/yyyy h:mm tt" },
        { "en-ZA", "yyyy/MM/dd HH:mm" },
        { "en-ZW", "M/d/yyyy h:mm tt" },
        { "es-AR", "dd/MM/yyyy HH:mm" },
        { "es-BO", "dd/MM/yyyy HH:mm" },
        { "es-CL", "dd-MM-yyyy HH:mm" },
        { "es-CO", "dd/MM/yyyy HH:mm" },
        { "es-CR", "dd/MM/yyyy HH:mm" },
        { "es-DO", "dd/MM/yyyy HH:mm" },
        { "es-EC", "dd/MM/yyyy HH:mm" },
        { "es-ES", "dd/MM/yyyy H:mm" },
        { "es-GT", "dd/MM/yyyy HH:mm" },
        { "es-HN", "dd/MM/yyyy HH:mm" },
        { "es-MX", "dd/MM/yyyy HH:mm" },
        { "es-NI", "dd/MM/yyyy HH:mm" },
        { "es-PA", "dd/MM/yyyy HH:mm" },
        { "es-PE", "dd/MM/yyyy HH:mm" },
        { "es-PR", "dd/MM/yyyy HH:mm" },
        { "es-PY", "dd/MM/yyyy HH:mm" },
        { "es-SV", "dd/MM/yyyy HH:mm" },
        { "es-US", "M/d/yyyy h:mm tt" },
        { "es-UY", "dd/MM/yyyy HH:mm" },
        { "es-VE", "dd/MM/yyyy HH:mm" },
        { "et-EE", "d.MM.yyyy HH:mm" },
        { "eu-ES", "yyyy/MM/dd HH:mm" },
        { "fa-IR", "yyyy/MM/dd HH:mm" },
        { "fi-FI", "d.M.yyyy H:mm" },
        { "fil-PH", "M/d/yyyy h:mm tt" },
        { "fo-FO", "dd-MM-yyyy HH:mm" },
        { "fr-BE", "d/MM/yyyy HH:mm" },
        { "fr-CA", "yyyy-MM-dd HH:mm" },
        { "fr-CH", "dd.MM.yyyy HH:mm" },
        { "fr-FR", "dd/MM/yyyy HH:mm" },
        { "fr-LU", "dd/MM/yyyy HH:mm" },
        { "fr-MC", "dd/MM/yyyy HH:mm" },
        { "fy-NL", "d-M-yyyy HH:mm" },
        { "ga-IE", "dd/MM/yyyy HH:mm" },
        { "gd-GB", "dd/MM/yyyy HH:mm" },
        { "gl-ES", "dd/MM/yy HH:mm" },
        { "gsw-FR", "dd/MM/yyyy HH:mm" },
        { "gu-IN", "dd-MM-yy h:mm tt" },
        { "ha-Latn-NG", "d/M/yyyy h:mm tt" },
        { "he-IL", "dd/MM/yyyy HH:mm" },
        { "hi-IN", "dd-MM-yyyy h:mm tt" },
        { "hr-BA", "d.M.yyyy. HH:mm" },
        { "hr-HR", "d.M.yyyy. HH:mm" },
        { "hsb-DE", "d. M. yyyy HH:mm" },
        { "hu-HU", "yyyy. MM. dd. HH:mm" },
        { "hy-AM", "dd.MM.yyyy HH:mm" },
        { "id-ID", "dd/MM/yyyy HH:mm" },
        { "ig-NG", "d/M/yyyy h:mm tt" },
        { "ii-CN", "yyyy/M/d H:mm" },
        { "is-IS", "d.M.yyyy HH:mm" },
        { "it-CH", "dd.MM.yyyy HH:mm" },
        { "it-IT", "dd/MM/yyyy HH:mm" },
        { "iu-Cans-CA", "yyyy-MM-dd HH:mm" },
        { "iu-Latn-CA", "yyyy-MM-dd HH:mm" },
        { "ja-JP", "yyyy/MM/dd H:mm" },
        { "ka-GE", "dd.MM.yyyy HH:mm" },
        { "kk-KZ", "dd.MM.yyyy HH:mm" },
        { "kl-GL", "dd-MM-yyyy HH:mm" },
        { "km-KH", "yyyy-MM-dd H:mm" },
        { "kn-IN", "dd-MM-yy h:mm tt" },
        { "ko-KR", "yyyy-MM-dd tt h:mm" },
        { "kok-IN", "dd-MM-yyyy h:mm tt" },
        { "lb-LU", "dd/MM/yyyy HH:mm" },
        { "lo-LA", "dd/MM/yyyy H:mm" },
        { "lt-LT", "yyyy-MM-dd HH:mm" },
        { "lv-LV", "dd.MM.yyyy HH:mm" },
        { "mi-NZ", "dd/MM/yyyy HH:mm" },
        { "mk-MK", "dd.MM.yyyy HH:mm" },
        { "ml-IN", "dd-MM-yy h:mm tt" },
        { "mn-MN", "yyyy.MM.dd HH:mm" },
        { "mn-Mong-CN", "yyyy/M/d H:mm" },
        { "moh-CA", "M/d/yyyy h:mm tt" },
        { "mr-IN", "dd-MM-yyyy h:mm tt" },
        { "ms-BN", "d/MM/yyyy HH:mm" },
        { "ms-MY", "d/MM/yyyy HH:mm" },
        { "mt-MT", "dd/MM/yyyy HH:mm" },
        { "nb-NO", "dd.MM.yyyy HH:mm" },
        { "ne-NP", "M/d/yyyy h:mm tt" },
        { "nl-BE", "d/MM/yyyy HH:mm" },
        { "nl-NL", "d-M-yyyy HH:mm" },
        { "nn-NO", "dd.MM.yyyy HH:mm" },
        { "nso-ZA", "yyyy/MM/dd HH:mm" },
        { "oc-FR", "dd/MM/yyyy HH:mm" },
        { "om-ET", "d/M/yyyy h:mm tt" },
        { "or-IN", "dd-MM-yy h:mm tt" },
        { "pa-IN", "dd-MM-yy h:mm tt" },
        { "pl-PL", "dd.MM.yyyy HH:mm" },
        { "prs-AF", "dd/MM/yy h:mm tt" },
        { "ps-AF", "dd/MM/yy h:mm tt" },
        { "pt-BR", "dd/MM/yyyy HH:mm" },
        { "pt-PT", "dd-MM-yyyy HH:mm" },
        { "quz-BO", "dd/MM/yyyy HH:mm" },
        { "quz-EC", "dd/MM/yyyy HH:mm" },
        { "quz-PE", "dd/MM/yyyy HH:mm" },
        { "rm-CH", "dd.MM.yyyy HH:mm" },
        { "ro-RO", "dd.MM.yyyy HH:mm" },
        { "ru-RU", "dd.MM.yyyy HH:mm" },
        { "rw-RW", "M/d/yyyy h:mm tt" },
        { "sah-RU", "MM.dd.yyyy HH:mm" },
        { "sa-IN", "dd-MM-yyyy h:mm tt" },
        { "se-FI", "d.M.yyyy HH:mm" },
        { "se-NO", "dd.MM.yyyy HH:mm" },
        { "se-SE", "yyyy-MM-dd HH:mm" },
        { "si-LK", "yyyy-MM-dd H:mm" },
        { "sk-SK", "d. M. yyyy H:mm" },
        { "sl-SI", "d. MM. yyyy HH:mm" },
        { "sma-NO", "dd.MM.yyyy HH:mm" },
        { "sma-SE", "yyyy-MM-dd HH:mm" },
        { "smj-NO", "dd.MM.yyyy HH:mm" },
        { "smj-SE", "yyyy-MM-dd HH:mm" },
        { "smn-FI", "d.M.yyyy HH:mm" },
        { "sms-FI", "d.M.yyyy HH:mm" },
        { "sq-AL", "yyyy-MM-dd HH:mm" },
        { "sr-Cyrl-BA", "d.M.yyyy. HH:mm" },
        { "sr-Cyrl-CS", "d.M.yyyy. HH:mm" },
        { "sr-Cyrl-ME", "d.M.yyyy. HH:mm" },
        { "sr-Cyrl-RS", "d.M.yyyy. HH:mm" },
        { "sr-Latn-BA", "d.M.yyyy. HH:mm" },
        { "sr-Latn-CS", "d.M.yyyy. HH:mm" },
        { "sr-Latn-ME", "d.M.yyyy. HH:mm" },
        { "sr-Latn-RS", "d.M.yyyy. HH:mm" },
        { "sv-FI", "d.M.yyyy HH:mm" },
        { "sv-SE", "yyyy-MM-dd HH:mm" },
        { "sw-KE", "M/d/yyyy h:mm tt" },
        { "ta-IN", "dd-MM-yyyy h:mm tt" },
        { "te-IN", "dd-MM-yy h:mm tt" },
        { "th-TH", "d/M/yyyy H:mm" },
        { "tk-TM", "dd.MM.yyyy HH:mm" },
        { "tn-ZA", "yyyy/MM/dd HH:mm" },
        { "tr-TR", "dd.MM.yyyy HH:mm" },
        { "tt-RU", "dd.MM.yyyy HH:mm" },
        { "tzm-Latn-DZ", "dd-MM-yyyy HH:mm" },
        { "ug-CN", "yyyy/M/d H:mm" },
        { "uk-UA", "dd.MM.yyyy HH:mm" },
        { "ur-PK", "dd/MM/yyyy HH:mm" },
        { "uz-Cyrl-UZ", "dd.MM.yyyy HH:mm" },
        { "uz-Latn-UZ", "dd/MM yyyy HH:mm" },
        { "vi-VN", "dd/MM/yyyy HH:mm" },
        { "wo-SN", "dd/MM/yyyy HH:mm" },
        { "xh-ZA", "yyyy/MM/dd HH:mm" },
        { "yo-NG", "d/M/yyyy h:mm tt" },
        { "zh-CN", "yyyy/M/d H:mm" },
        { "zh-HK", "d/M/yyyy H:mm" },
        { "zh-MO", "d/M/yyyy H:mm" },
        { "zh-SG", "d/M/yyyy H:mm" },
        { "zh-TW", "yyyy/M/d H:mm" },
        { "zu-ZA", "yyyy/MM/dd HH:mm" }
    };

    private const string DefaultFormat = "yyyy-MM-dd HH:mm";

    private static string GetShortDateTimeFormat(string cultureName)
    {
        if (ShortDateTimeFormats.TryGetValue(cultureName, out string? format))
        {
            return format;
        }

        // Try language only (e.g., "en")
        int dashIndex = cultureName.IndexOf('-');
        string langOnly = dashIndex > 0 ? cultureName.Substring(0, dashIndex) : cultureName;

        cultureName = GetMainCultureSpecifier(langOnly);
        if (ShortDateTimeFormats.TryGetValue(cultureName, out format))
        {
            return format;
        }

        return DefaultFormat;
    }

    private static string GetMainCultureSpecifier(string language)
    {
        language = language.Trim().ToLowerInvariant();

        // Map of language-only codes to their "main" full specifier in .NET 8
        // Source: CultureInfo.GetCultureInfo("xx") and .NET 8 culture list
        return language switch
        {
            "af" => "af-ZA",
            "am" => "am-ET",
            "ar" => "ar-SA",
            "as" => "as-IN",
            "az" => "az-Latn-AZ",
            "be" => "be-BY",
            "bg" => "bg-BG",
            "bn" => "bn-IN",
            "bo" => "bo-CN",
            "bs" => "bs-Latn-BA",
            "ca" => "ca-ES",
            "cs" => "cs-CZ",
            "cy" => "cy-GB",
            "da" => "da-DK",
            "de" => "de-DE",
            "dv" => "dv-MV",
            "el" => "el-GR",
            "en" => "en-US",
            "es" => "es-ES",
            "et" => "et-EE",
            "eu" => "eu-ES",
            "fa" => "fa-IR",
            "fi" => "fi-FI",
            "fil" => "fil-PH",
            "fo" => "fo-FO",
            "fr" => "fr-FR",
            "fy" => "fy-NL",
            "ga" => "ga-IE",
            "gd" => "gd-GB",
            "gl" => "gl-ES",
            "gu" => "gu-IN",
            "ha" => "ha-Latn-NG",
            "he" => "he-IL",
            "hi" => "hi-IN",
            "hr" => "hr-HR",
            "hsb" => "hsb-DE",
            "hu" => "hu-HU",
            "hy" => "hy-AM",
            "id" => "id-ID",
            "ig" => "ig-NG",
            "is" => "is-IS",
            "it" => "it-IT",
            "ja" => "ja-JP",
            "ka" => "ka-GE",
            "kk" => "kk-KZ",
            "km" => "km-KH",
            "kn" => "kn-IN",
            "ko" => "ko-KR",
            "kok" => "kok-IN",
            "lb" => "lb-LU",
            "lo" => "lo-LA",
            "lt" => "lt-LT",
            "lv" => "lv-LV",
            "mi" => "mi-NZ",
            "mk" => "mk-MK",
            "ml" => "ml-IN",
            "mn" => "mn-MN",
            "mr" => "mr-IN",
            "ms" => "ms-MY",
            "mt" => "mt-MT",
            "nb" => "nb-NO",
            "ne" => "ne-NP",
            "nl" => "nl-NL",
            "nn" => "nn-NO",
            "oc" => "oc-FR",
            "or" => "or-IN",
            "pa" => "pa-IN",
            "pl" => "pl-PL",
            "prs" => "prs-AF",
            "ps" => "ps-AF",
            "pt" => "pt-BR",
            "quz" => "quz-PE",
            "rm" => "rm-CH",
            "ro" => "ro-RO",
            "ru" => "ru-RU",
            "rw" => "rw-RW",
            "sa" => "sa-IN",
            "se" => "se-NO",
            "si" => "si-LK",
            "sk" => "sk-SK",
            "sl" => "sl-SI",
            "sq" => "sq-AL",
            "sr" => "sr-Cyrl-RS",
            "sv" => "sv-SE",
            "sw" => "sw-KE",
            "ta" => "ta-IN",
            "te" => "te-IN",
            "th" => "th-TH",
            "tk" => "tk-TM",
            "tn" => "tn-ZA",
            "tr" => "tr-TR",
            "tt" => "tt-RU",
            "ug" => "ug-CN",
            "uk" => "uk-UA",
            "ur" => "ur-PK",
            "uz" => "uz-Latn-UZ",
            "vi" => "vi-VN",
            "wo" => "wo-SN",
            "xh" => "xh-ZA",
            "yo" => "yo-NG",
            "zh" => "zh-CN",
            "zu" => "zu-ZA",
            _ => "en-US" // fallback
        };
    }
}
