#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')

## BuildUtc Class

An [IBuildUtc](Xecrets.Licensing.Abstractions.IBuildUtc.md 'Xecrets.Licensing.Abstractions.IBuildUtc') implementation using assembly meta data, like: [assembly: AssemblyMetadata("BuildUtc",  
"[Build DateTime]")] The value can also be "UseExecutableDateTime" in which case we'll use the time stamp of the  
executable file instead, and also consider this a GPL build. The idea is that a CI build process will replace the  
"UseExecutableDateTime" placeholder value of the BuildUtc attribute with the actual build time, thus enabling a  
nicely directly buildable open source project, while still being able to perform internal builds with a specific  
build time.

```csharp
public class BuildUtc :
Xecrets.Licensing.Abstractions.IBuildUtc
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; BuildUtc

Implements [IBuildUtc](Xecrets.Licensing.Abstractions.IBuildUtc.md 'Xecrets.Licensing.Abstractions.IBuildUtc')

### Remarks
The [System.Reflection.AssemblyTitleAttribute](https://docs.microsoft.com/en-us/dotnet/api/System.Reflection.AssemblyTitleAttribute 'System.Reflection.AssemblyTitleAttribute') is also inspected to determine if the build is a beta build. If it contains  
the word "BETA" it's considered a beta build. Also here the expectation is that a CI build would remove the "BETA"  
from the title for a release build. As a fallback for testing, if the value is "UseExecutableDateTime", a check is  
made for environment variable XF_BUILDUTC, and if it's set, that value is used instead.
### Constructors

<a name='Xecrets.Licensing.Implementation.BuildUtc.BuildUtc(System.Type)'></a>

## BuildUtc(Type) Constructor

Create an instance, using the provided type as a reference to the executable assembly.

```csharp
public BuildUtc(System.Type assemblyType);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.BuildUtc.BuildUtc(System.Type).assemblyType'></a>

`assemblyType` [System.Type](https://docs.microsoft.com/en-us/dotnet/api/System.Type 'System.Type')

A type from the assembly to consider the exectuable.
### Properties

<a name='Xecrets.Licensing.Implementation.BuildUtc.BuildUtcText'></a>

## BuildUtc.BuildUtcText Property

Return a culture invariant string representation of the build time, or what should be considered the build time.

```csharp
public string BuildUtcText { get; }
```

Implements [BuildUtcText](Xecrets.Licensing.Abstractions.IBuildUtc.md#Xecrets.Licensing.Abstractions.IBuildUtc.BuildUtcText 'Xecrets.Licensing.Abstractions.IBuildUtc.BuildUtcText')

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='Xecrets.Licensing.Implementation.BuildUtc.IsBetaBuild'></a>

## BuildUtc.IsBetaBuild Property

Return [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if this is a beta build. Exactly how this is determined is decided by the  
implementation.

```csharp
public bool IsBetaBuild { get; }
```

Implements [IsBetaBuild](Xecrets.Licensing.Abstractions.IBuildUtc.md#Xecrets.Licensing.Abstractions.IBuildUtc.IsBetaBuild 'Xecrets.Licensing.Abstractions.IBuildUtc.IsBetaBuild')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Xecrets.Licensing.Implementation.BuildUtc.IsDebugBuild'></a>

## BuildUtc.IsDebugBuild Property

Return [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if this is a debug build. Exactly how this is determined is decided by the  
implementation.

```csharp
public bool IsDebugBuild { get; }
```

Implements [IsDebugBuild](Xecrets.Licensing.Abstractions.IBuildUtc.md#Xecrets.Licensing.Abstractions.IBuildUtc.IsDebugBuild 'Xecrets.Licensing.Abstractions.IBuildUtc.IsDebugBuild')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='Xecrets.Licensing.Implementation.BuildUtc.IsGplBuild'></a>

## BuildUtc.IsGplBuild Property

Return [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if this is a GPL build, depending on the implementation it may signify any type of  
open source license, making the licensing irrelevant for the build.

```csharp
public bool IsGplBuild { get; }
```

Implements [IsGplBuild](Xecrets.Licensing.Abstractions.IBuildUtc.md#Xecrets.Licensing.Abstractions.IBuildUtc.IsGplBuild 'Xecrets.Licensing.Abstractions.IBuildUtc.IsGplBuild')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')