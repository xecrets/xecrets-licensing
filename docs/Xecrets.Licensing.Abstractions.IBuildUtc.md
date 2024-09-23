#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions')

## IBuildUtc Interface

Handle build date and time and GPL test

```csharp
public interface IBuildUtc
```

Derived  
&#8627; [BuildUtc](Xecrets.Licensing.Implementation.BuildUtc.md 'Xecrets.Licensing.Implementation.BuildUtc')
### Properties

<a name='Xecrets.Licensing.Abstractions.IBuildUtc.BuildUtcText'></a>

## IBuildUtc.BuildUtcText Property

Return a culture invariant string representation of the build time, or what should be considered the build time.

```csharp
string BuildUtcText { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Licensing.Abstractions.IBuildUtc.IsBetaBuild'></a>

## IBuildUtc.IsBetaBuild Property

Return [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if this is a beta build. Exactly how this is determined is decided by the  
implementation.

```csharp
bool IsBetaBuild { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Xecrets.Licensing.Abstractions.IBuildUtc.IsDebugBuild'></a>

## IBuildUtc.IsDebugBuild Property

Return [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if this is a debug build. Exactly how this is determined is decided by the  
implementation.

```csharp
bool IsDebugBuild { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Xecrets.Licensing.Abstractions.IBuildUtc.IsGplBuild'></a>

## IBuildUtc.IsGplBuild Property

Return [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if this is a GPL build, depending on the implementation it may signify any type of  
open source license, making the licensing irrelevant for the build.

```csharp
bool IsGplBuild { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')