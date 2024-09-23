#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')

## License Class

Select, validate and interpret the best available license

```csharp
public class License :
Xecrets.Licensing.Abstractions.ILicense
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; License

Implements [ILicense](Xecrets.Licensing.Abstractions.ILicense.md 'Xecrets.Licensing.Abstractions.ILicense')
### Properties

<a name='Xecrets.Licensing.Implementation.License.LicenseToken'></a>

## License.LicenseToken Property

The raw license token string that was loaded, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

```csharp
public string LicenseToken { get; set; }
```

Implements [LicenseToken](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LicenseToken 'Xecrets.Licensing.Abstractions.ILicense.LicenseToken')

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Xecrets.Licensing.Implementation.License.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_)'></a>

## License.GetBestValidLicenseTokenAsync(IEnumerable<string>) Method

Determine the best license from a list of candidates.

```csharp
public System.Threading.Tasks.Task<string> GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable<string> candidates);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_).candidates'></a>

`candidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The list of license candidates.

Implements [GetBestValidLicenseTokenAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable<string>)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The best license token string, or an empty string

<a name='Xecrets.Licensing.Implementation.License.LoadFromAsync(System.Collections.Generic.IEnumerable_string_)'></a>

## License.LoadFromAsync(IEnumerable<string>) Method

Load the best license from a list of candidates.

```csharp
public System.Threading.Tasks.Task LoadFromAsync(System.Collections.Generic.IEnumerable<string> licenseCandidates);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.LoadFromAsync(System.Collections.Generic.IEnumerable_string_).licenseCandidates'></a>

`licenseCandidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The list of license candidates.

Implements [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
A waitable [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='Xecrets.Licensing.Implementation.License.Status()'></a>

## License.Status() Method

The [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus') of the loaded license, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

```csharp
public Xecrets.Licensing.Abstractions.LicenseStatus Status();
```

Implements [Status()](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Status() 'Xecrets.Licensing.Abstractions.ILicense.Status()')

#### Returns
[LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus')  
The loaded [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus').

<a name='Xecrets.Licensing.Implementation.License.Status(Xecrets.Licensing.Implementation.LicenseSubscription)'></a>

## License.Status(LicenseSubscription) Method

A [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus') from the [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

```csharp
public Xecrets.Licensing.Abstractions.LicenseStatus Status(Xecrets.Licensing.Implementation.LicenseSubscription subscription);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.Status(Xecrets.Licensing.Implementation.LicenseSubscription).subscription'></a>

`subscription` [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

A [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

Implements [Status(LicenseSubscription)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Status(Xecrets.Licensing.Implementation.LicenseSubscription) 'Xecrets.Licensing.Abstractions.ILicense.Status(Xecrets.Licensing.Implementation.LicenseSubscription)')

#### Returns
[LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus')  
A [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus')

<a name='Xecrets.Licensing.Implementation.License.Subscription()'></a>

## License.Subscription() Method

The [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') that was loaded, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

```csharp
public Xecrets.Licensing.Implementation.LicenseSubscription Subscription();
```

Implements [Subscription()](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Subscription() 'Xecrets.Licensing.Abstractions.ILicense.Subscription()')

#### Returns
[LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

<a name='Xecrets.Licensing.Implementation.License.Subscription(string)'></a>

## License.Subscription(string) Method

A [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') instantiated by interpreting a raw license token string

```csharp
public Xecrets.Licensing.Implementation.LicenseSubscription Subscription(string signedLicense);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.Subscription(string).signedLicense'></a>

`signedLicense` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The raw signed license token string, it's assumed it is a proper token

Implements [Subscription(string)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Subscription(string) 'Xecrets.Licensing.Abstractions.ILicense.Subscription(string)')

#### Returns
[LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')  
The [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') or an empty if the [signedLicense](Xecrets.Licensing.Implementation.License.md#Xecrets.Licensing.Implementation.License.Subscription(string).signedLicense 'Xecrets.Licensing.Implementation.License.Subscription(string).signedLicense') was an empty string.

<a name='Xecrets.Licensing.Implementation.License.ValidSignatureLicenses(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_)'></a>

## License.ValidSignatureLicenses(string, IEnumerable<string>, List<string>) Method

Get licenses with valid signatures. They may still be expired, or invalid for this product.

```csharp
private System.Threading.Tasks.Task ValidSignatureLicenses(string keyPem, System.Collections.Generic.IEnumerable<string> candidates, System.Collections.Generic.List<string> validSignedLicenses);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.ValidSignatureLicenses(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_).keyPem'></a>

`keyPem` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Licensing.Implementation.License.ValidSignatureLicenses(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_).candidates'></a>

`candidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='Xecrets.Licensing.Implementation.License.ValidSignatureLicenses(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_).validSignedLicenses'></a>

`validSignedLicenses` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')