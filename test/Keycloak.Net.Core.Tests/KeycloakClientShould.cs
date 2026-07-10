using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        private static readonly KeycloakClient _client = CreateKeycloakClient();
        private static readonly KeycloakTestFixture _fixture = new(_client);

        private static KeycloakClient CreateKeycloakClient()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
														  .AddJsonFile("appsettings.json",
																	   optional: true,
																	   reloadOnChange: true)
														  .Build();

            var url = configuration["url"]!;
            var userName = configuration["userName"]!;
            var password = configuration["password"]!;

            return new(url, userName, password);
        }

        private static readonly Lazy<HashSet<string>> _enabledFeatures = new(() =>
        {
            var info = _client.GetServerInfoAsync("master").GetAwaiter().GetResult();
            return new HashSet<string>(
                info.Features?.Where(f => f.Enabled).Select(f => f.Name) ?? Enumerable.Empty<string>(),
                StringComparer.OrdinalIgnoreCase);
        });

        internal static bool IsServerFeatureEnabled(string featureName) => _enabledFeatures.Value.Contains(featureName);
    }
}
