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
/// Methods to determine what might be a license. It is only a heuristic, and not a guarante, typically implemented by
/// length and pattern matching what could be a JWT license token, but not necessarily a valid one.
/// </summary>
public interface ILicenseCandidates
{
    /// <summary>
    /// Inspect file contents and determine by heuristics if they are likely to be a license or not.
    /// </summary>
    /// <param name="files">An enumeration of full path names to files to check.</param>
    /// <returns>An enumeration of possible candidates (not necessarily actual licenses).</returns>
    IEnumerable<string> CandidatesFromFiles(IEnumerable<string> files);

    /// <summary>
    /// Test and if it appears to be likely candidate, extract the license string from a file.
    /// </summary>
    /// <param name="file">The file to check.</param>
    /// <param name="candidateLicenseToken">The license candidate, or an empty string.</param>
    /// <returns><see langword="true"/> if a license candidate is returned, otherwise <see langword="false"/>.</returns>
    bool TryCandidateFile(string file, out string candidateLicenseToken);

    /// <summary>
    /// Clean and extract a license token from a candidate string.
    /// </summary>
    /// <param name="candidate"></param>
    /// <returns>A probably clean license token string, or an empty string if it doesn't match</returns>
    string ExtractCandidate(string? candidate);
}
