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

The raw license token string that was loaded, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)'), or an empty  
string.

```csharp
public string LicenseToken { get; set; }
```

Implements [LicenseToken](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LicenseToken 'Xecrets.Licensing.Abstractions.ILicense.LicenseToken')

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Xecrets.Licensing.Implementation.License.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_)'></a>

## License.GetBestValidLicenseTokenAsync(IEnumerable<string>) Method

Determine the best license from a list of candidates. What is the best license is determined by the  
implementation.

```csharp
public System.Threading.Tasks.Task<string> GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable<string> licenseTokenCandidates);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_).licenseTokenCandidates'></a>

`licenseTokenCandidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The list of license candidates.

Implements [GetBestValidLicenseTokenAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable<string>)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The best license token string, or an empty string if no candidate was valid.

<a name='Xecrets.Licensing.Implementation.License.LoadFromAsync(System.Collections.Generic.IEnumerable_string_)'></a>

## License.LoadFromAsync(IEnumerable<string>) Method

Load the best license from a list of candidates. What is the best license is determined by the implementation.  
If no license is found, the [LicenseToken](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LicenseToken 'Xecrets.Licensing.Abstractions.ILicense.LicenseToken') will be an empty string.

```csharp
public System.Threading.Tasks.Task LoadFromAsync(System.Collections.Generic.IEnumerable<string> licenseTokenCandidates);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.LoadFromAsync(System.Collections.Generic.IEnumerable_string_).licenseTokenCandidates'></a>

`licenseTokenCandidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The list of license candidates.

Implements [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
A waitable [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='Xecrets.Licensing.Implementation.License.Status()'></a>

## License.Status() Method

The [LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus') of the loaded license, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

```csharp
public Xecrets.Licensing.Abstractions.LicenseStatus Status();
```

Implements [Status()](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Status() 'Xecrets.Licensing.Abstractions.ILicense.Status()')

#### Returns
[LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus')  
The loaded [LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus').

<a name='Xecrets.Licensing.Implementation.License.Status(Xecrets.Licensing.Implementation.LicenseSubscription)'></a>

## License.Status(LicenseSubscription) Method

A [LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus') from the [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

```csharp
public Xecrets.Licensing.Abstractions.LicenseStatus Status(Xecrets.Licensing.Implementation.LicenseSubscription subscription);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.Status(Xecrets.Licensing.Implementation.LicenseSubscription).subscription'></a>

`subscription` [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

A [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

Implements [Status(LicenseSubscription)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Status(Xecrets.Licensing.Implementation.LicenseSubscription) 'Xecrets.Licensing.Abstractions.ILicense.Status(Xecrets.Licensing.Implementation.LicenseSubscription)')

#### Returns
[LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus')  
A [LicenseStatus](Xecrets.Licensing.Abstractions.LicenseStatus.md 'Xecrets.Licensing.Abstractions.LicenseStatus')

<a name='Xecrets.Licensing.Implementation.License.Subscription()'></a>

## License.Subscription() Method

The [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') that was loaded, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)') or  
[Empty](Xecrets.Licensing.Implementation.LicenseSubscription.md#Xecrets.Licensing.Implementation.LicenseSubscription.Empty 'Xecrets.Licensing.Implementation.LicenseSubscription.Empty') .

```csharp
public Xecrets.Licensing.Implementation.LicenseSubscription Subscription();
```

Implements [Subscription()](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Subscription() 'Xecrets.Licensing.Abstractions.ILicense.Subscription()')

#### Returns
[LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')  
The [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription').

<a name='Xecrets.Licensing.Implementation.License.Subscription(string)'></a>

## License.Subscription(string) Method

A [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') instantiated by interpreting a raw license token string

```csharp
public Xecrets.Licensing.Implementation.LicenseSubscription Subscription(string signedLicense);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.Subscription(string).signedLicense'></a>

`signedLicense` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [Subscription(string)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Subscription(string) 'Xecrets.Licensing.Abstractions.ILicense.Subscription(string)')

#### Returns
[LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')  
The [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') or [Empty](Xecrets.Licensing.Implementation.LicenseSubscription.md#Xecrets.Licensing.Implementation.LicenseSubscription.Empty 'Xecrets.Licensing.Implementation.LicenseSubscription.Empty') if the licenseToken was an empty string.

<a name='Xecrets.Licensing.Implementation.License.ValidLicenseTokens(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_)'></a>

## License.ValidLicenseTokens(string, IEnumerable<string>, List<string>) Method

Get licenses with valid signatures. They may still be expired, or invalid for this product.

```csharp
private System.Threading.Tasks.Task ValidLicenseTokens(string publicKeyPem, System.Collections.Generic.IEnumerable<string> licenseTokenCandidates, System.Collections.Generic.List<string> validLicenseTokens);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.License.ValidLicenseTokens(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_).publicKeyPem'></a>

`publicKeyPem` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Licensing.Implementation.License.ValidLicenseTokens(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_).licenseTokenCandidates'></a>

`licenseTokenCandidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

<a name='Xecrets.Licensing.Implementation.License.ValidLicenseTokens(string,System.Collections.Generic.IEnumerable_string_,System.Collections.Generic.List_string_).validLicenseTokens'></a>

`validLicenseTokens` [System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')