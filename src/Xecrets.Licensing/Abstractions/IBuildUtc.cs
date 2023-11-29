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

namespace Xecrets.Licensing.Abstractions
{
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
}
