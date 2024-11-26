#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Implementation](Xecrets.Licensing.Implementation.md 'Xecrets.Licensing.Implementation')

## LicenseCandidates Class

Check files and strings if the could be a license candidate by way of heuristics. The purpose is to  
speed things up and determine actions without the need to actually attempt to validate a license.

```csharp
public class LicenseCandidates :
Xecrets.Licensing.Abstractions.ILicenseCandidates
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; LicenseCandidates

Implements [ILicenseCandidates](Xecrets.Licensing.Abstractions.ILicenseCandidates.md 'Xecrets.Licensing.Abstractions.ILicenseCandidates')
### Methods

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.CandidatesFromFiles(System.Collections.Generic.IEnumerable_string_)'></a>

## LicenseCandidates.CandidatesFromFiles(IEnumerable<string>) Method

Inspect file contents and determine by heuristics if they are likely to be a license or not.

```csharp
public System.Collections.Generic.IEnumerable<string> CandidatesFromFiles(System.Collections.Generic.IEnumerable<string> files);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.CandidatesFromFiles(System.Collections.Generic.IEnumerable_string_).files'></a>

`files` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

An enumeration of full path names to files to check.

Implements [CandidatesFromFiles(IEnumerable&lt;string&gt;)](Xecrets.Licensing.Abstractions.ILicenseCandidates.md#Xecrets.Licensing.Abstractions.ILicenseCandidates.CandidatesFromFiles(System.Collections.Generic.IEnumerable_string_) 'Xecrets.Licensing.Abstractions.ILicenseCandidates.CandidatesFromFiles(System.Collections.Generic.IEnumerable<string>)')

#### Returns
[System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')  
An enumeration of possible candidates (not necessarily actual licenses).

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.IsCandidate(string)'></a>

## LicenseCandidates.IsCandidate(string) Method

Test if a provided string is a license candidate.

```csharp
public bool IsCandidate(string? candidate);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.IsCandidate(string).candidate'></a>

`candidate` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Implements [IsCandidate(string)](Xecrets.Licensing.Abstractions.ILicenseCandidates.md#Xecrets.Licensing.Abstractions.ILicenseCandidates.IsCandidate(string) 'Xecrets.Licensing.Abstractions.ILicenseCandidates.IsCandidate(string)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if it is a license candidate, otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.JwtRegex()'></a>

## LicenseCandidates.JwtRegex() Method

```csharp
private static System.Text.RegularExpressions.Regex JwtRegex();
```

#### Returns
[System.Text.RegularExpressions.Regex](https://docs.microsoft.com/en-us/dotnet/api/System.Text.RegularExpressions.Regex 'System.Text.RegularExpressions.Regex')

### Remarks
Pattern:<br/>  
  
```csharp  
^eyJ[-_a-zA-Z0-9]+\\.eyJ[-_a-zA-Z0-9]+\\.[-_a-zA-Z0-9]+$  
```<br/>  
Options:<br/>  
  
```csharp  
RegexOptions.Compiled  
```<br/>  
Explanation:<br/>  
  
```csharp  
○ Match if at the beginning of the string.<br/>  
○ Match the string "eyJ".<br/>  
○ Match a character in the set [-0-9A-Z_a-z] atomically at least once.<br/>  
○ Match the string ".eyJ".<br/>  
○ Match a character in the set [-0-9A-Z_a-z] atomically at least once.<br/>  
○ Match '.'.<br/>  
○ Match a character in the set [-0-9A-Z_a-z] atomically at least once.<br/>  
○ Match if at the end of the string or if before an ending newline.<br/>  
```

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.TryCandidateFile(string,string)'></a>

## LicenseCandidates.TryCandidateFile(string, string) Method

Test and if it appears to be likely candidate, extract the license string from a file.

```csharp
public bool TryCandidateFile(string file, out string candidateLicenseToken);
```
#### Parameters

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.TryCandidateFile(string,string).file'></a>

`file` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The file to check.

<a name='Xecrets.Licensing.Implementation.LicenseCandidates.TryCandidateFile(string,string).candidateLicenseToken'></a>

`candidateLicenseToken` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

The license candidate, or an empty string.

Implements [TryCandidateFile(string, string)](Xecrets.Licensing.Abstractions.ILicenseCandidates.md#Xecrets.Licensing.Abstractions.ILicenseCandidates.TryCandidateFile(string,string) 'Xecrets.Licensing.Abstractions.ILicenseCandidates.TryCandidateFile(string, string)')

#### Returns
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')  
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if a license candidate is returned, otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').