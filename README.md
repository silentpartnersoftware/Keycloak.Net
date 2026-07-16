![Icon](https://raw.github.com/silentpartnersoftware/Keycloak.Net/01f1654e44065409726b417e26b2dfc913e03c7f/docs/icon.png)
# Keycloak.Net.Core
[![license](https://img.shields.io/github/license/AnderssonPeter/Keycloak.Net.svg?maxAge=2592000)](https://github.com/AnderssonPeter/Keycloak.Net/blob/master/LICENSE) [![NuGet](https://img.shields.io/nuget/v/Keycloak.Net.Core?maxAge=2592000)](https://www.nuget.org/packages/Keycloak.Net.Core/) [![downloads](https://img.shields.io/nuget/dt/Keycloak.Net.Core)](https://www.nuget.org/packages/Keycloak.Net.Core/)

 A Fork of https://github.com/lvermeulen/Keycloak.Net with some additional patches
 * allow usage of CancellationTokens
 * changed ClientConfig to Dictionary<string, string>
 * removed signing
 * .NET 8 and .NET 10 support only
 * updated for keycloak version 26+
 * added support for changing default `AdminClientId` which has default `admin-cli` value
 * added support for System.Text.Json in replacement of NewtonsoftJson.

 To use different AdminClientId, use newly introduced KeyCloakOptions:
  ```cs
 new KeycloakClient(
    "http://keycloak.url",
    "adminUserName",
    "adminPassword",
    new KeycloakOptions(adminClientId:"admin"
    )
);
 ```

 ## Older version support for using /auth path
 When creating a new KeycloakClient, use newly introduced KeycloakOptions:
 ```cs
 new KeycloakClient(
    "http://keycloak.url",
    "adminUserName",
    "adminPassword",
    new KeycloakOptions(prefix:"auth"
    )
);
 ```

C# client for [Keycloak](https://www.keycloak.org/) 26.x

See documentation at [https://www.keycloak.org/docs-api/latest/rest-api/](https://www.keycloak.org/docs-api/latest/rest-api/)

## Features
* [X] Attack Detection
* [X] Authentication Management
* [X] Client Attribute Certificate
* [X] Client Initial Access
* [X] Client Registration Policy
* [X] Client Role Mappings
* [X] Client Scopes
* [X] Clients
* [X] Component
* [X] Groups
* [X] Identity Providers
* [X] Key
* [X] Protocol Mappers
* [X] Realms Admin
* [X] Role Mapper
* [X] Roles
* [X] Roles (by ID)
* [X] Scope Mappings
* [X] User Storage Provider
* [X] Users
* [X] Root

## Testing

The easiest way to run the tests is to use the fixture launcher:

```bash
./build/start-keycloak.sh --test --auto-cleanup
```

This starts Keycloak 26.7.0 in Docker, imports `/test/keycloak-net-fixture-realm-export.json`, runs the tests, and removes the container when the run completes.

To start the fixture server without running tests:

```bash
./build/start-keycloak.sh
```

The fixture realm is `keycloak-net-fixture`. The tests use the credentials in `/test/Keycloak.Net.Core.Tests/appsettings.json`; the fixture export includes the matching realm admin user.

If you prefer to run Keycloak manually, import `/test/keycloak-net-fixture-realm-export.json` into a Keycloak 26.7.0 instance before running the tests. The imported realm must be available at `keycloak-net-fixture`, and the credentials in `/test/Keycloak.Net.Core.Tests/appsettings.json` must match the realm admin user included in the export.
