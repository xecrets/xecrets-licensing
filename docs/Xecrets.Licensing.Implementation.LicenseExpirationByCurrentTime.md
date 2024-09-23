#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')

## LicenseExpirationByCurrentTime Class

An [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') implementation comparing the license with the current date and time.

```csharp
public class LicenseExpirationByCurrentTime :
Xecrets.Licensing.Abstractions.ILicenseExpiration
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LicenseExpirationByCurrentTime

Implements [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration')
### Constructors

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime.LicenseExpirationByCurrentTime(System.TimeProvider)'></a>

## LicenseExpirationByCurrentTime(TimeProvider) Constructor

An [ILicenseExpiration](Xecrets.Licensing.Abstractions.ILicenseExpiration.md 'Xecrets.Licensing.Abstractions.ILicenseExpiration') implementation comparing the license with the current date and time.

```csharp
public LicenseExpirationByCurrentTime(System.TimeProvider timeProvider);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime.LicenseExpirationByCurrentTime(System.TimeProvider).timeProvider'></a>

`timeProvider` [System.TimeProvider](https://docs.microsoft.com/en-us/dotnet/api/System.TimeProvider 'System.TimeProvider')
### Methods

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime.IsExpired(System.DateTime)'></a>

## LicenseExpirationByCurrentTime.IsExpired(DateTime) Method

Check if the license has expired, as determined by comparing the build time with the current time.  
The current time is determined by the [System.TimeProvider](https://docs.microsoft.com/en-us/dotnet/api/System.TimeProvider 'System.TimeProvider') implementation.

```csharp
public bool IsExpired(System.DateTime expiresUtc);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime.IsExpired(System.DateTime).expiresUtc'></a>

`expiresUtc` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

The date and time when it expires.

Implements [IsExpired(DateTime)](Xecrets.Licensing.Abstractions.ILicenseExpiration.md#Xecrets.Licensing.Abstractions.ILicenseExpiration.IsExpired(System.DateTime) 'Xecrets.Licensing.Abstractions.ILicenseExpiration.IsExpired(System.DateTime)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the license is determined to have expired.