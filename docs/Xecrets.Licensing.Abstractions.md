#### [Xecrets.Licensing](index.md 'index')

## Xecrets.Licensing.Abstractions Namespace

The Xecrets.Licensing.Abstractions namespace contains the interfaces that are used to interact with the licensing  
system. There are various implementations of these interfaces in the [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')  
namespace, or you can roll your own for your specific needs.

| Interfaces | |
| :--- | :--- |
| [IBuildUtc](Xecrets.Licensing.Abstractions.IBuildUtc.md 'Xecrets.Licensing.Abstractions.IBuildUtc') | Handle build date and time and GPL test |
| [ILicense](Xecrets.Licensing.Abstractions.ILicense.md 'Xecrets.Licensing.Abstractions.ILicense') | Select, validate and interpret the best available license |
| [ILicenseCandidates](Xecrets.Licensing.Abstractions.ILicenseCandidates.md 'Xecrets.Licensing.Abstractions.ILicenseCandidates') | Methods to determine what might be a license, and to deterimine if in fact a candidate <br/>is a license. |
| [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') | An interface for determining license expiration by whatever method is appropriate<br/>for the product. |
| [INewLocator](Xecrets.Licensing.Abstractions.INewLocator.md 'Xecrets.Licensing.Abstractions.INewLocator') | A dependency locator |
### Enums

<a name='Xecrets.Licensing.Abstractions.LicenseStatus'></a>

## LicenseStatus Enum

The license status enumeration, naming the different states a license can be in.

```csharp
public enum LicenseStatus
```
### Fields

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Expired'></a>

`Expired` 3

It's a build requiring a license, but the subscription license is not valid because the license has expired  
Splash blurb is longer and explains the specific situation.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Gpl'></a>

`Gpl` 1

It's a GPL build and subscription licensing is irrelevant.  
Splash blurb politely and concisely asks to get a subscription.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Invalid'></a>

`Invalid` 5

It's a build requiring a license, but the subscription while not expired is not valid for  
this software.  
Splash blurb is longer and explains the specific situation.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.None'></a>

`None` 0

No, or unknown, state. Should never be used.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Unlicensed'></a>

`Unlicensed` 2

It's a build requiring a license, but there is no subscription license at all.  
Splash blurb is longer and explains the specific situation.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Valid'></a>

`Valid` 4

It's a build requiring a license, and the subscription license is valid for this version.  
Splash blurb politely and concisely thanks for the contribution.