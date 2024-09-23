#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions')

## ILicense Interface

Select, validate and interpret the best available license

```csharp
public interface ILicense
```

Derived  
&#8627; [License](Xecrets.Licensing.Implementation.License.md 'Xecrets.Licensing.Implementation.License')
### Properties

<a name='Xecrets.Licensing.Abstractions.ILicense.LicenseToken'></a>

## ILicense.LicenseToken Property

The raw license token string that was loaded, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

```csharp
string LicenseToken { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')
### Methods

<a name='Xecrets.Licensing.Abstractions.ILicense.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_)'></a>

## ILicense.GetBestValidLicenseTokenAsync(IEnumerable<string>) Method

Determine the best license from a list of candidates.

```csharp
System.Threading.Tasks.Task<string> GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable<string> candidates);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicense.GetBestValidLicenseTokenAsync(System.Collections.Generic.IEnumerable_string_).candidates'></a>

`candidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The list of license candidates.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')  
The best license token string, or an empty string

<a name='Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_)'></a>

## ILicense.LoadFromAsync(IEnumerable<string>) Method

Load the best license from a list of candidates.

```csharp
System.Threading.Tasks.Task LoadFromAsync(System.Collections.Generic.IEnumerable<string> licenseCandidates);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_).licenseCandidates'></a>

`licenseCandidates` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

The list of license candidates.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')  
A waitable [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='Xecrets.Licensing.Abstractions.ILicense.Status()'></a>

## ILicense.Status() Method

The [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus') of the loaded license, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

```csharp
Xecrets.Licensing.Abstractions.LicenseStatus Status();
```

#### Returns
[LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus')  
The loaded [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus').

<a name='Xecrets.Licensing.Abstractions.ILicense.Status(Xecrets.Licensing.Implementation.LicenseSubscription)'></a>

## ILicense.Status(LicenseSubscription) Method

A [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus') from the [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

```csharp
Xecrets.Licensing.Abstractions.LicenseStatus Status(Xecrets.Licensing.Implementation.LicenseSubscription subscription);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicense.Status(Xecrets.Licensing.Implementation.LicenseSubscription).subscription'></a>

`subscription` [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

A [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

#### Returns
[LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus')  
A [LicenseStatus](Xecrets.Licensing.Abstractions.md#Xecrets.Licensing.Abstractions.LicenseStatus 'Xecrets.Licensing.Abstractions.LicenseStatus')

<a name='Xecrets.Licensing.Abstractions.ILicense.Subscription()'></a>

## ILicense.Subscription() Method

The [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') that was loaded, [LoadFromAsync(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicense.LoadFromAsync(System.Collections.Generic.IEnumerable<string>)')

```csharp
Xecrets.Licensing.Implementation.LicenseSubscription Subscription();
```

#### Returns
[LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')

<a name='Xecrets.Licensing.Abstractions.ILicense.Subscription(string)'></a>

## ILicense.Subscription(string) Method

A [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') instantiated by interpreting a raw license token string

```csharp
Xecrets.Licensing.Implementation.LicenseSubscription Subscription(string signedLicense);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicense.Subscription(string).signedLicense'></a>

`signedLicense` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The raw signed license token string, it's assumed it is a proper token

#### Returns
[LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription')  
The [LicenseSubscription](Xecrets.Licensing.Implementation.LicenseSubscription.md 'Xecrets.Licensing.Implementation.LicenseSubscription') or an empty if the [signedLicense](Xecrets.Licensing.Abstractions.ILicense.md#Xecrets.Licensing.Abstractions.ILicense.Subscription(string).signedLicense 'Xecrets.Licensing.Abstractions.ILicense.Subscription(string).signedLicense') was an empty string.