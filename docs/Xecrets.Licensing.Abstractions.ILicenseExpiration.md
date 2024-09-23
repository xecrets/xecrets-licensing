#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions')

## ILicenseExpiration Interface

An interface for determining license expiration by whatever method is appropriate  
for the product.

```csharp
public interface ILicenseExpiration
```

Derived  
&#8627; [LicenseExpirationByBuildTime](Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime.md 'Xecrets.Licensing.Implementation.LicenseExpirationByBuildTime')  
&#8627; [LicenseExpirationByCurrentTime](Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime.md 'Xecrets.Licensing.Implementation.LicenseExpirationByCurrentTime')
### Methods

<a name='Xecrets.Licensing.Abstractions.ILicenseExpiration.IsExpired(System.DateTime)'></a>

## ILicenseExpiration.IsExpired(DateTime) Method

Check if the license has expired

```csharp
bool IsExpired(System.DateTime expiresUtc);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicenseExpiration.IsExpired(System.DateTime).expiresUtc'></a>

`expiresUtc` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

The date and time when it expires.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if the license is determined to have expired.