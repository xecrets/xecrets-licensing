#region Copyright and License

/*
 * Xecrets Licensing - Copyright © 2022-2024, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 * 
 * Unless explicitly licensed in writing, this source code is the sole property of Axantum Software AB,
 * and may not be copied, distributed, sold, modified or otherwise used in any way.
*/

#endregion Copyright and License

namespace Xecrets.Licensing.Abstractions
{
    /// <summary>
    /// Methods to determine what might be a license, and to deterimine if in fact a candidate 
    /// is a license.
    /// </summary>
    public interface ILicenseCandidates
    {
        /// <summary>
        /// Inspect files and determine by heuristics if they are likely to be a license or not.
        /// </summary>
        /// <param name="files">An enumeration of full path names to files to check.</param>
        /// <returns>An enumeration of possible candidates (not necessarily actual licenses).</returns>
        IEnumerable<string> CandidatesFromFiles(IEnumerable<string> files);

        /// <summary>
        /// Test and if so, extract the license string from a file.
        /// </summary>
        /// <param name="file">The file to check.</param>
        /// <param name="candidateLicense">The license candidate, or an empty string.</param>
        /// <returns><see langword="true"/> if a license candidate is returned, otherwise <see langword="false"/>.</returns>
        bool TryCandidateFile(string file, out string candidateLicense);

        /// <summary>
        /// Test if a provided string is a license candidate
        /// </summary>
        /// <param name="candidate">The candidate string to test.</param>
        /// <returns><see langword="true"/> if it is a license candidate, otherwise <see langword="false"/>.</returns>
        bool IsCandidate(string? candidate);
    }
}
