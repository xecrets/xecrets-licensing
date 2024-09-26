#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')

## LicenseSubscription Class

The subscription, with an expiration, a licensee and valid for a product

```csharp
public class LicenseSubscription
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LicenseSubscription

### Remarks
Instantiate a subscription
### Constructors

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.LicenseSubscription(System.DateTime,string,string,Xecrets.Licensing.Abstractions.LicenseType)'></a>

## LicenseSubscription(DateTime, string, string, LicenseType) Constructor

The subscription, with an expiration, a licensee and valid for a product

```csharp
public LicenseSubscription(System.DateTime expirationUtc, string licensee, string product, Xecrets.Licensing.Abstractions.LicenseType licenseType);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.LicenseSubscription(System.DateTime,string,string,Xecrets.Licensing.Abstractions.LicenseType).expirationUtc'></a>

`expirationUtc` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

The date and time of expiration.

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.LicenseSubscription(System.DateTime,string,string,Xecrets.Licensing.Abstractions.LicenseType).licensee'></a>

`licensee` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The licensee, an arbitrary string representing the holder of the license.

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.LicenseSubscription(System.DateTime,string,string,Xecrets.Licensing.Abstractions.LicenseType).product'></a>

`product` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The product that is licensed, an arbitrary string.

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.LicenseSubscription(System.DateTime,string,string,Xecrets.Licensing.Abstractions.LicenseType).licenseType'></a>

`licenseType` [LicenseType](Xecrets.Licensing.Abstractions.LicenseType.md 'Xecrets.Licensing.Abstractions.LicenseType')

The type of license.

### Remarks
Instantiate a subscription
### Fields

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.Empty'></a>

## LicenseSubscription.Empty Field

An empty default subscription

```csharp
public static readonly LicenseSubscription Empty;
```

#### Field Value
[LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')
### Properties

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.ExpirationUtc'></a>

## LicenseSubscription.ExpirationUtc Property

The date and time of expiration.

```csharp
public System.DateTime ExpirationUtc { get; }
```

#### Property Value
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.Licensee'></a>

## LicenseSubscription.Licensee Property

The licensee, an arbitrary string representing the holder of the license.

```csharp
public string Licensee { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.LicenseType'></a>

## LicenseSubscription.LicenseType Property

The type of license, free, trial, paid etc.

```csharp
public Xecrets.Licensing.Abstractions.LicenseType LicenseType { get; }
```

#### Property Value
[LicenseType](Xecrets.Licensing.Abstractions.LicenseType.md 'Xecrets.Licensing.Abstractions.LicenseType')

<a name='Xecrets.Licensing.Implementation.LicenseSubscription.Product'></a>

## LicenseSubscription.Product Property

The product that is licensed, an arbitrary string.

```csharp
public string Product { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')