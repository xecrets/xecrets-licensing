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
using System.Reflection;

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation
{
    /// <summary>
    /// An <see cref="IBuildUtc"/> implementation using assembly meta data, like:
    /// [assembly: AssemblyMetadata("BuildUtc", "[Build DateTime]")]
    /// The value can also be "UseExecutableDateTime" in which case we'll use the time stamp
    /// of the executable instead, and also consider this a GPL build.
    /// </summary>
    /// <remarks>
    /// As a fallback for testing, if the value is "UseExecutableDateTime", a check is made
    /// for environment variable XF_BUILDUTC, and if it's set, that value is used instead.
    /// </remarks>
    public class BuildUtc : IBuildUtc
    {
        private const string UseExecutableDateTime = "UseExecutableDateTime";

        private readonly Assembly _assembly;

        private readonly string _assemblyBuildUtcText;

        /// <summary>
        /// Create an instance, using the provided type as a reference to the executable assembly.
        /// </summary>
        /// <param name="assemblyType">A type from the assembly to consider the exectuable.</param>
        public BuildUtc(Type assemblyType)
        {
            _assembly = assemblyType.Assembly;
            _assemblyBuildUtcText = GetAssemblyBuildUtcText();
            IsGplBuild = _assemblyBuildUtcText == UseExecutableDateTime;
            BuildUtcText = GetBuildUtcText();
            IsBetaBuild = _assembly.GetCustomAttribute<AssemblyTitleAttribute>()?.Title.Contains("BETA") ?? false;
        }

        /// <inheritdoc/>
        public bool IsDebugBuild =>
#if DEBUG
            true;
#else
            false;
#endif

        /// <inheritdoc/>
        public bool IsBetaBuild { get; }

        /// <inheritdoc/>
        public string BuildUtcText { get; }

        /// <inheritdoc/>
        public bool IsGplBuild { get; }

        private string GetBuildUtcText()
        {
            string GetExecutableDateTime()
            {
                string name = Path.Combine(System.AppContext.BaseDirectory, _assembly.GetName().Name ?? throw new InvalidOperationException("Unexpected null assembly name."));
                name += System.IO.File.Exists(name + ".exe") ? ".exe" : (System.IO.File.Exists(name + ".dll") ? ".dll" : string.Empty);
                string dateTime = System.IO.File.GetLastWriteTimeUtc(name).ToString(CultureInfo.InvariantCulture);
                return dateTime;
            }

            string buildUtcText = IsGplBuild ? GetExecutableDateTime() : _assemblyBuildUtcText;

            return buildUtcText;
        }

        private string GetAssemblyBuildUtcText()
        {
            string assemblyBuildUtcText = _assembly.GetCustomAttributes<AssemblyMetadataAttribute>().Where(a => a.Key == "BuildUtc").Select(a => a.Value).First()
                ?? throw new InvalidOperationException("Internal error, missing AssemblyMetadataAttribute BuildUtc");

            if (assemblyBuildUtcText != UseExecutableDateTime)
            {
                return assemblyBuildUtcText;
            }

            string? buildUtcEnv = Environment.GetEnvironmentVariable("XF_BUILDUTC");
            return string.IsNullOrEmpty(buildUtcEnv) ? assemblyBuildUtcText : buildUtcEnv;
        }
    }
}
