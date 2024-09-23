#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions')

## LicenseStatus Enum

The license status enumeration, naming the different states a license can be in.

```csharp
public enum LicenseStatus
```
### Fields

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Expired'></a>

`Expired` 3

It's a build requiring a license, but the subscription license is not valid because the license has expired  
[LicenseBlurb](Xecrets.Licensing.Implementation.LicenseBlurb.md 'Xecrets.Licensing.Implementation.LicenseBlurb') is longer and explains the specific situation.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Gpl'></a>

`Gpl` 1

It's a GPL build and subscription licensing is irrelevant.  
[LicenseBlurb](Xecrets.Licensing.Implementation.LicenseBlurb.md 'Xecrets.Licensing.Implementation.LicenseBlurb') politely and concisely asks to get a subscription.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Invalid'></a>

`Invalid` 5

It's a build requiring a license, but the subscription while not expired is not valid for this software. [LicenseBlurb](Xecrets.Licensing.Implementation.LicenseBlurb.md 'Xecrets.Licensing.Implementation.LicenseBlurb') is longer and explains the specific situation.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.None'></a>

`None` 0

No, or unknown, state. Should never be used.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Unlicensed'></a>

`Unlicensed` 2

It's a build requiring a license, but there is no subscription license at all.  
[LicenseBlurb](Xecrets.Licensing.Implementation.LicenseBlurb.md 'Xecrets.Licensing.Implementation.LicenseBlurb') is longer and explains the specific situation.

<a name='Xecrets.Licensing.Abstractions.LicenseStatus.Valid'></a>

`Valid` 4

It's a build requiring a license, and the subscription license is valid for this version.  
[LicenseBlurb](Xecrets.Licensing.Implementation.LicenseBlurb.md 'Xecrets.Licensing.Implementation.LicenseBlurb') politely and concisely thanks for the contribution.