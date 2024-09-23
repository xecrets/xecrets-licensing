# xecrets-licensing

Xecrets Licensing - JWT Software License Handling

# Introduction 

Xecrets Licensing is a software licensing system that uses JSON Web Tokens (JWT) to handle software
licensing. It is designed to be simple to use and easy to integrate into your software. By
leveraging JWTs, Xecrets Licensing is able to provide a secure and flexible licensing within a well
established and widely used standard.

It can work with any JWTs that are signed with a secret key, but it is specifically designed to work
together with the [Xecrets Cli command line](https://github.com/xecrets/xecrets-cli) tool, which
provides command line functions to generate appropriate JWT licenses, as well as key pairs for
signing and verifying the JWTs.

Xecrets Licensing is built with .NET 8.0 and is available as a NuGet package, and will run on any
platform supporting .NET 8.0, including Windows, Linux, and macOS.

# Concepts

Xecrets Licensing is built around the following concepts:

- An expiration time, which is the time when the license will expire. Exactly how this is determined
is determined by the implementation of
[ILicenseExpiration](docs/Xecrets.Licensing.Abstractions.ILicenseExpiration.md
'Xecrets.Licensing.Abstraction.ILicenseExpiration') .
 
- The type of the build, which can be a combination of GPL, Beta and Debug, as well as what should
be considered the build time of the assembly. This is determined by the implementation of
[IBuildUtc](docs/Xecrets.Licensing.Abstractions.IBuildUtc.md
'Xecrets.Licensing.Abstractions.IBuildUtc') .

- A license status, which can be any of the values of
[LicenseStatus](docs/Xecrets.Licensing.Abstractions.LicenseStatus.md
'Xecrets.Licensing.Abstractions.LicenseStatus') which are: GPL, Unlicensed, Expired, Valid or
Invalid.

- A licensee, which is the entity that the license is issued to. This can be any string determined
by the implementation, but typically something tied to the user of the license such as an email
address. This is encoded as the audience of the JWT.

- A product, which is the product that the license is for. This can be any string determined by the
implementation, typically a short code representing the product being licensed. This is encoded as a
claim in the JWT.

# Dependency injection

Xecrets Licensing is designed to be used with dependency injection, but it is agnostic to the actual
implementation. Therefore there is an
[INewLocator](docs/Xecrets.Licensing.Abstractions.INewLocator.md
'Xecrets.Licensing.Abstractions.INewLocator') interface that must be implemented to enable the
library to create instances as determined by the consuming implementation. There is no default
implementation, it must be provided by the consumer.

# Quick start

To get started with Xecrets Licensing, you need to add the NuGet package to your project.

You also need a JWT key pair to sign and verify the JWTs. You can generate a key pair using [Xecrets Cli](https://github.com/xecrets/xecrets-cli):

```cmd
XecretsCli --jwt-create-key-pair {private-pem} {public-pem}
```

You can specify a file path, or '-' for standard input, and '+' for standard output. A key pair
intended for use with JWT algorithm ES256 is generated.

Once you have the key pair, you need to keep the private key secret and private. The public
key can for example be published with your software. It is not secret.

You can use any method you chose to sign a JWT license, including Xecrets Cli, Node.js and C#. This
is not included in Xecrets Licensing, as it's intended for use in the licensed application
primarily.

Here's how Xecrets Cli does it C#:

```csharp
var now = New<INow>().Utc;
var handler = new JsonWebTokenHandler();

var key = ECDsa.Create();
key.ImportFromPem(parameters.JwtPrivateKeyPem.Replace("\\n", Environment.NewLine));
string token = handler.CreateToken(new SecurityTokenDescriptor
{
    Issuer = parameters.JwtIssuer,
    Audience = parameters.JwtAudience,
    NotBefore = now,
    Expires = now.AddDays(parameters.JwtDaysUntilExpiration),
    IssuedAt = now,
    Claims = parameters.JwtClaims,
    SigningCredentials = new SigningCredentials(new ECDsaSecurityKey(key), SecurityAlgorithms.EcdsaSha256)
});
```

Of course you can use Xecrets Cli to do it from a script or the command line:
    
```cmd
XecretsCli.exe --overwrite --jwt-audience licensee@example.com --jwt-claims 365 "{""myclaim.example.com"":""myapp""}" --jwt-issuer me@example.com --jwt-private-key private.pem --jwt-sign license.txt
```

This will use the provided private.pem key and create or overwrite a file named license.txt with a
signed JWT license that expires in 365 days, with the audience licensee@example.com, the issuer
me@example.com and the claim myclaim.example.com=myapp. Beware quoting rules for your command line,
the above is for Windows cmd.

Given the above JWT license, you can verify it in C# with Xecrets Licensing something like this,
somewhat abbreviated:

```csharp
private static ServiceProvider _serviceProvider;
...
internal class NewLocator : INewLocator
{
    public T New<T>() where T : class
    {
        return (T)(_serviceProvider.GetService(typeof(T))!;
    }
}
...
    .AddSingleton<ILicense>((_) => new License(new NewLocator(), issuer: "me@example.com", claim: "myclaim.example.com", [LicensePublicKey], ["myapp"]))
...
public class MyLicenseChecker(ILicense license)
{
    public async Task<bool> IsLicensed(string licenseCandidate)
    {
        await license.LoadFromAsync([licenseCandidate])
        return license.Status() == LicenseStatus.Valid;
    }
}
```

The license validation will ensure that the license is signed with the correct private key, and that
the claim is correct and that it is not expired, assuming you are using the Xecrets Licensing
default implementation of ILicense.

# API documentation

The full API documentation is available in the [docs](docs/index.md 'docs') folder. The full source
is available on https://github.com/xecrets/xecrets-licensing and example use can be seen in
https://github.com/xecrets/xecrets-cli .