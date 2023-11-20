#region Coypright and License

/*
 * Xecrets Licensing - Copyright © 2022-2023, Svante Seleborg, All Rights Reserved.
 *
 * This code file is part of Xecrets Licensing
 * 
 * Unless explicitly licensed in writing, this source code is the sole property of Axantum Software AB,
 * and may not be copied, distributed, sold, modified or otherwise used in any way.
*/

#endregion Coypright and License

using System.Text.RegularExpressions;

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation
{
    /// <summary>
    /// Check files and strings if the could be a license candidate by way of heuristics. The purpose is to
    /// speed things up and determine actions without the need to actually attempt to validate a license.
    /// </summary>
    public partial class LicenseCandidates : ILicenseCandidates
    {
        /// <inheritdoc/>
        public IEnumerable<string> CandidatesFromFiles(IEnumerable<string> files)
        {
            List<string> candidateLicenses = [];

            foreach (string file in files)
            {
                if (TryCandidateFile(file, out string candidateLicense))
                {
                    candidateLicenses.Add(candidateLicense);
                }
            }

            return candidateLicenses;
        }

        /// <inheritdoc/>
        public bool TryCandidateFile(string file, out string candidateLicense)
        {
            candidateLicense = string.Empty;
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

            if (IsCandidate(fileText))
            {
                candidateLicense = fileText;
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool IsCandidate(string? candidate)
        {
            candidate = candidate?.Trim();
            return !string.IsNullOrEmpty(candidate) && candidate.Length < 1024 && _jwtRegex.IsMatch(candidate);
        }

        private static readonly Regex _jwtRegex = JwtRegex();

        [GeneratedRegex(@"^[-_a-zA-Z0-9]+\.[-_a-zA-Z0-9]+\.[-_a-zA-Z0-9]+$", RegexOptions.Compiled)]
        private static partial Regex JwtRegex();
    }
}
