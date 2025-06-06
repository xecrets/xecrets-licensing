#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions')

## ILicenseCandidates Interface

Methods to determine what might be a license. It is only a heuristic, and not a guarante, typically implemented by  
length and pattern matching what could be a JWT license token, but not necessarily a valid one.

```csharp
public interface ILicenseCandidates
```

Derived  
&#8627; [LicenseCandidates](Xecrets.Licensing.Implementation.LicenseCandidates.md 'Xecrets.Licensing.Implementation.LicenseCandidates')
### Methods

<a name='Xecrets.Licensing.Abstractions.ILicenseCandidates.CandidatesFromFiles(System.Collections.Generic.IEnumerable_string_)'></a>

## ILicenseCandidates.CandidatesFromFiles(IEnumerable<string>) Method

Inspect file contents and determine by heuristics if they are likely to be a license or not.

```csharp
System.Collections.Generic.IEnumerable<string> CandidatesFromFiles(System.Collections.Generic.IEnumerable<string> files);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicenseCandidates.CandidatesFromFiles(System.Collections.Generic.IEnumerable_string_).files'></a>

`files` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

An enumeration of full path names to files to check.

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An enumeration of possible candidates (not necessarily actual licenses).

<a name='Xecrets.Licensing.Abstractions.ILicenseCandidates.IsCandidate(string)'></a>

## ILicenseCandidates.IsCandidate(string) Method

Test if a provided string is a license candidate.

```csharp
bool IsCandidate(string? candidateLicenseToken);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicenseCandidates.IsCandidate(string).candidateLicenseToken'></a>

`candidateLicenseToken` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The candidate string to test.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if it is a license candidate, otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='Xecrets.Licensing.Abstractions.ILicenseCandidates.TryCandidateFile(string,string)'></a>

## ILicenseCandidates.TryCandidateFile(string, string) Method

Test and if it appears to be likely candidate, extract the license string from a file.

```csharp
bool TryCandidateFile(string file, out string candidateLicenseToken);
```
#### Parameters

<a name='Xecrets.Licensing.Abstractions.ILicenseCandidates.TryCandidateFile(string,string).file'></a>

`file` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file to check.

<a name='Xecrets.Licensing.Abstractions.ILicenseCandidates.TryCandidateFile(string,string).candidateLicenseToken'></a>

`candidateLicenseToken` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The license candidate, or an empty string.

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if a license candidate is returned, otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').