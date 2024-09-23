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

using System.Globalization;
using System.Reflection;

using Xecrets.Licensing.Abstractions;

namespace Xecrets.Licensing.Implementation;

/// <summary>
/// An <see cref="IBuildUtc"/> implementation using assembly meta data, like: [assembly: AssemblyMetadata("BuildUtc",
/// "[Build DateTime]")] The value can also be "UseExecutableDateTime" in which case we'll use the time stamp of the
/// executable file instead, and also consider this a GPL build. The idea is that a CI build process will replace the
/// "UseExecutableDateTime" placeholder value of the BuildUtc attribute with the actual build time, thus enabling a
/// nicely directly buildable open source project, while still being able to perform internal builds with a specific
/// build time.
/// </summary>
/// <remarks>
/// The <see cref="AssemblyTitleAttribute"/> is also inspected to determine if the build is a beta build. If it contains
/// the word "BETA" it's considered a beta build. Also here the expectation is that a CI build would remove the "BETA"
/// from the title for a release build. As a fallback for testing, if the value is "UseExecutableDateTime", a check is
/// made for environment variable XF_BUILDUTC, and if it's set, that value is used instead.
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
