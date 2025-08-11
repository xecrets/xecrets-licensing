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

using System.Text.RegularExpressions;

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation;

/// <summary>
/// Check files and strings if the could be a license candidate by way of heuristics. The purpose is to
/// speed things up and determine actions without the need to actually attempt to validate a license.
/// </summary>
public partial class LicenseCandidates : ILicenseCandidates
{
    /// <inheritdoc/>
    public IEnumerable<string> CandidatesFromFiles(IEnumerable<string> files)
    {
        List<string> candidateLicenseTokens = [];

        foreach (string file in files)
        {
            if (TryCandidateFile(file, out string candidateLicenseToken))
            {
                candidateLicenseTokens.Add(candidateLicenseToken);
            }
        }

        return candidateLicenseTokens;
    }

    /// <inheritdoc/>
    public bool TryCandidateFile(string file, out string candidateLicenseToken)
    {
        candidateLicenseToken = string.Empty;
        FileInfo fileInfo = new FileInfo(file);
        if (fileInfo.Length is > 1024 or < 100)
        {
            return false;
        }

        string fileText;
        try
        {
            fileText = System.IO.File.ReadAllText(file);
        }
        catch (IOException)
        {
            return false;
        }

        string candidate = ExtractCandidate(fileText);
        if (candidate.Length > 0)
        {
            candidateLicenseToken = fileText;
            return true;
        }

        return false;
    }

    /// <inheritdoc/>
    public string ExtractCandidate(string? candidate)
    {
        string compact = WhiteSpaceRegex().Replace(candidate ?? string.Empty, string.Empty);

        Match match = JwtEs256Regex().Match(compact);
        if (!match.Success)
        {
            return string.Empty;
        }

        return match.Value;
    }

    [GeneratedRegex(@"\s+")]
    private static partial Regex WhiteSpaceRegex();

    /// <summary>
    /// A regular expression to match a JWT ES256 token. The first part is the header, the second part is the payload,
    /// the third part is the signature. The first two parts have reasonable limits to their lengths set, while the
    /// signature has an exact length set in order to avoid matching trailing characters.
    /// </summary>
    [GeneratedRegex(@"(eyJ[A-Za-z0-9_-]{5,50})\.(eyJ[A-Za-z0-9_-]{50,1000})\.([A-Za-z0-9_-]{86})")]
    private static partial Regex JwtEs256Regex();
}
