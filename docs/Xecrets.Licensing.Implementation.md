#### [Xecrets.Licensing](index.md 'index')

## Xecrets.Licensing.Implementation Namespace

The Xecrets.Licensing.Implementation namespace contains various default implementations of the abstractions from  
[Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions').

| Classes | |
| :--- | :--- |
| [BuildUtc](Xecrets.Licensing.Implementation.BuildUtc.md 'Xecrets.Licensing.Implementation.BuildUtc') | An [IBuildUtc](Xecrets.Licensing.Abstractions.IBuildUtc.md 'Xecrets.Licensing.Abstractions.IBuildUtc') implementation using assembly meta data, like:<br/>[assembly: AssemblyMetadata("BuildUtc", "[Build DateTime]")]<br/>The value can also be "UseExecutableDateTime" in which case we'll use the time stamp<br/>of the executable instead, and also consider this a GPL build. |
| [License](Xecrets.Licensing.Implementation.License.md 'Xecrets.Licensing.Implementation.License') | Select, validate and interpret the best available license |
| [LicenseBlurb](Xecrets.Licensing.Implementation.LicenseBlurb.md 'Xecrets.Licensing.Implementation.LicenseBlurb') | Create appropriate license message blurbs depending on the license situation. |
| [LicenseCandidates](Xecrets.Licensing.Implementation.LicenseCandidates.md 'Xecrets.Licensing.Implementation.LicenseCandidates') | Check files and strings if the could be a license candidate by way of heuristics. The purpose is to<br/>speed things up and determine actions without the need to actually attempt to validate a license. |
| [LicenseExpirationByBuildTime](Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime.md 'Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime') | An [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') implementation comparing the license with date and time of the build. |
| [LicenseExpirationByCurrentTime](Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime.md 'Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime') | An [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') implementation comparing the license with the current date and time. |
| [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') | The subscription, with an expiration, a licensee and valid for a product |
