#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions')

## LicenseType Enum

Different types of license that may be issued.

```csharp
public enum LicenseType
```
### Fields

<a name='Xecrets.Licensing.Abstractions.LicenseType.Free'></a>

`Free` 1

A complimentary free premium license. Coded as "free" in the license.

<a name='Xecrets.Licensing.Abstractions.LicenseType.FreeTest'></a>

`FreeTest` 2

A free premium trial license, gained without entering any payment details or starting  
a subscription. Coded as "test" in the license.

<a name='Xecrets.Licensing.Abstractions.LicenseType.None'></a>

`None` 0

Unknown or no license type

<a name='Xecrets.Licensing.Abstractions.LicenseType.Paid'></a>

`Paid` 4

A paid premium license. Coded as "paid" in the license.

<a name='Xecrets.Licensing.Abstractions.LicenseType.Trial'></a>

`Trial` 3

A payment premium trial license, a free period before a credit card is charged.  
Coded as "trial" in the license.