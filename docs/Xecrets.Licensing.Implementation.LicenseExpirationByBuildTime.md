#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')

## LicenseExpirationByBuildTime Class

An [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') implementation comparing the license with date and time of the build.

```csharp
public class LicenseExpirationByBuildTime :
Xecrets.Licensing.Abstractions.ILicenseExpiration
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LicenseExpirationByBuildTime

Implements [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration')

### Remarks
Instantiate an instance providing a locator
### Constructors

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime.LicenseExpirationByBuildTime(Xecrets.Licensing.Abstractions.INewLocator)'></a>

## LicenseExpirationByBuildTime(INewLocator) Constructor

An [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') implementation comparing the license with date and time of the build.

```csharp
public LicenseExpirationByBuildTime(Xecrets.Licensing.Abstractions.INewLocator newLocator);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime.LicenseExpirationByBuildTime(Xecrets.Licensing.Abstractions.INewLocator).newLocator'></a>

`newLocator` [INewLocator](Xecrets.Licensing.Abstractions.INewLocator.md 'Xecrets.Licensing.Abstractions.INewLocator')

The [INewLocator](Xecrets.Licensing.Abstractions.INewLocator.md 'Xecrets.Licensing.Abstractions.INewLocator') to use to get dependencies.

### Remarks
Instantiate an instance providing a locator
### Methods

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime.IsExpired(System.DateTime)'></a>

## LicenseExpirationByBuildTime.IsExpired(DateTime) Method

Check if the license has expired, as determined by comparing the build time with the expiration time.  
The build time is determined by the [IBuildUtc](Xecrets.Licensing.Abstractions.IBuildUtc.md 'Xecrets.Licensing.Abstractions.IBuildUtc') implementation.

```csharp
public bool IsExpired(System.DateTime expiresUtc);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime.IsExpired(System.DateTime).expiresUtc'></a>

`expiresUtc` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

The date and time when it expires.

Implements [IsExpired(DateTime)](Xecrets.Licensing.Abstractions.ILicenseExpiration.md#Xecrets.Licensing.Abstractions.ILicenseExpiration.IsExpired(System.DateTime) 'Xecrets.Licensing.Abstractions.ILicenseExpiration.IsExpired(System.DateTime)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the license is determined to have expired.