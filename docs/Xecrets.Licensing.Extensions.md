#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing](Xecrets.Licensing.md 'Xecrets.Licensing')

## Extensions Class

Utility extensions

```csharp
public static class Extensions
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Extensions
### Methods

<a name='Xecrets.Licensing.Extensions.FromUtc(thisstring)'></a>

## Extensions.FromUtc(this string) Method

Convert a UTC string to a [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime') in UTC.

```csharp
public static System.DateTime FromUtc(this string utcDateTime);
```
#### Parameters

<a name='Xecrets.Licensing.Extensions.FromUtc(thisstring).utcDateTime'></a>

`utcDateTime` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

<a name='Xecrets.Licensing.Extensions.ToLocal(thisstring)'></a>

## Extensions.ToLocal(this string) Method

Convert a UTC string to a local string.

```csharp
public static string ToLocal(this string utcDateTime);
```
#### Parameters

<a name='Xecrets.Licensing.Extensions.ToLocal(thisstring).utcDateTime'></a>

`utcDateTime` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Licensing.Extensions.ToLocal(thisSystem.DateTime)'></a>

## Extensions.ToLocal(this DateTime) Method

Convert a UTC [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime') to a string in local format.

```csharp
public static string ToLocal(this System.DateTime utcDateTime);
```
#### Parameters

<a name='Xecrets.Licensing.Extensions.ToLocal(thisSystem.DateTime).utcDateTime'></a>

`utcDateTime` [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')

#### Returns
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')