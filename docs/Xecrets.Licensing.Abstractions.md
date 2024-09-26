#### [Xecrets.Licensing](index.md 'index')

## Xecrets.Licensing.Abstractions Namespace

The Xecrets.Licensing.Abstractions namespace contains the interfaces that are used to interact with the licensing  
system. There are various implementations of these interfaces in the [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')  
namespace, or you can roll your own for your specific needs.

| Interfaces | |
| :--- | :--- |
| [IBuildUtc](Xecrets.Licensing.Abstractions.IBuildUtc.md 'Xecrets.Licensing.Abstractions.IBuildUtc') | Handle build date and time and GPL test |
| [ILicense](Xecrets.Licensing.Abstractions.ILicense.md 'Xecrets.Licensing.Abstractions.ILicense') | Select, validate and interpret the best available license |
| [ILicenseCandidates](Xecrets.Licensing.Abstractions.ILicenseCandidates.md 'Xecrets.Licensing.Abstractions.ILicenseCandidates') | Methods to determine what might be a license. It is only a heuristic, and not a guarante, typically implemented by<br/>length and pattern matching what could be a JWT license token, but not necessarily a valid one. |
| [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') | An interface for determining license expiration by whatever method is appropriate<br/>for the product. |
| [INewLocator](Xecrets.Licensing.Abstractions.INewLocator.md 'Xecrets.Licensing.Abstractions.INewLocator') | A dependency locator |

| Enums | |
| :--- | :--- |
| [LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus') | The license status enumeration, naming the different states a license can be in. |
| [LicenseType](Xecrets.Licensing.Abstractions.LicenseType.md 'Xecrets.Licensing.Abstractions.LicenseType') | Different types of license that may be issued. |
