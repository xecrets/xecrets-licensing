#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')

## LicenseBlurb Class

A helper to create appropriate license message blurbs depending on the license situation.

```csharp
public class LicenseBlurb
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LicenseBlurb

### Remarks
Create an instance of the LicenseBlurb class, providing text templates. Where appropriate, use the following  
placeholders:  
Literal "\n" - will be replaced by the appropriate new line for the environment.  
{licensee} - will be replaced by the licensee from the license.  
{expiration} - will be replaced by the license expiration in InvariantCulture formatting.  
{product} - will be replaced by the product the license is valid for.
### Constructors

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator,string,string,string,string,string)'></a>

## LicenseBlurb(INewLocator, string, string, string, string, string) Constructor

A helper to create appropriate license message blurbs depending on the license situation.

```csharp
public LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator newLocator, string gplBlurb, string unlicensedBlurb, string expiredBlurb, string licensedBlurb, string invalidBlurb);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator,string,string,string,string,string).newLocator'></a>

`newLocator` [INewLocator](Xecrets.Licensing.Abstractions.INewLocator.md 'Xecrets.Licensing.Abstractions.INewLocator')

A reference to a [INewLocator](Xecrets.Licensing.Abstractions.INewLocator.md 'Xecrets.Licensing.Abstractions.INewLocator') to locate dependencies.

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator,string,string,string,string,string).gplBlurb'></a>

`gplBlurb` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A text template for a GPL license.

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator,string,string,string,string,string).unlicensedBlurb'></a>

`unlicensedBlurb` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A text template for the case when there is no license.

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator,string,string,string,string,string).expiredBlurb'></a>

`expiredBlurb` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A text template for the case when a previously valid license has expired.

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator,string,string,string,string,string).licensedBlurb'></a>

`licensedBlurb` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A text template for the case when the license is valid.

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.LicenseBlurb(Xecrets.Licensing.Abstractions.INewLocator,string,string,string,string,string).invalidBlurb'></a>

`invalidBlurb` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

A text template for the case when the license is not valid for this product.

### Remarks
Create an instance of the LicenseBlurb class, providing text templates. Where appropriate, use the following  
placeholders:  
Literal "\n" - will be replaced by the appropriate new line for the environment.  
{licensee} - will be replaced by the licensee from the license.  
{expiration} - will be replaced by the license expiration in InvariantCulture formatting.  
{product} - will be replaced by the product the license is valid for.
### Methods

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.ToString()'></a>

## LicenseBlurb.ToString() Method

Get the appropriate license blurb for the current license loaded via [ILicense](Xecrets.Licensing.Abstractions.ILicense.md 'Xecrets.Licensing.Abstractions.ILicense')

```csharp
public override string ToString();
```

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
An appropriate string.

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.ToString(Xecrets.Licensing.Abstractions.LicenseStatus,Xecrets.Licensing.Implementation.LicenseSubscription)'></a>

## LicenseBlurb.ToString(LicenseStatus, LicenseSubscription) Method

Get the appropriate license blurb for the provided [LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus') and [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

```csharp
public virtual string ToString(Xecrets.Licensing.Abstractions.LicenseStatus status, Xecrets.Licensing.Implementation.LicenseSubscription subscription);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.ToString(Xecrets.Licensing.Abstractions.LicenseStatus,Xecrets.Licensing.Implementation.LicenseSubscription).status'></a>

`status` [LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus')

The status

<a name='Xecrets.Licensing.Implementation.LicenseBlurb.ToString(Xecrets.Licensing.Abstractions.LicenseStatus,Xecrets.Licensing.Implementation.LicenseSubscription).subscription'></a>

`subscription` [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

The subscription

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')  
An appropriate string.