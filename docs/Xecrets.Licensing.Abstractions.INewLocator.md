#### [Xecrets.Licensing](index.md 'index')
### [Xecrets.Licensing.Abstractions](Xecrets.Licensing.Abstractions.md 'Xecrets.Licensing.Abstractions')

## INewLocator Interface

A dependency locator

```csharp
public interface INewLocator
```
### Methods

<a name='Xecrets.Licensing.Abstractions.INewLocator.New_T_()'></a>

## INewLocator.New<T>() Method

Locate an instance of the give type.

```csharp
T New<T>()
    where T : class;
```
#### Type parameters

<a name='Xecrets.Licensing.Abstractions.INewLocator.New_T_().T'></a>

`T`

The type to find an instance for.

#### Returns
[T](Xecrets.Licensing.Abstractions.INewLocator.md#Xecrets.Licensing.Abstractions.INewLocator.New_T_().T 'Xecrets.Licensing.Abstractions.INewLocator.New<T>().T')  
An instance of the given type.