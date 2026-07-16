using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetComponentsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetComponentsAsync(realm);
            var componentNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("Allowed Client Scopes", componentNames);
            Assert.Contains("rsa-generated", componentNames);
        }

        [Fact]
        public async Task GetComponentAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var components = await _client.GetComponentsAsync(realm);
            var component = components.First(x => x.ProviderId == "rsa-generated");

            var result = await _client.GetComponentAsync(realm, component.Id);

            Assert.Equal(component.Id, result.Id);
            Assert.Equal("rsa-generated", result.Name);
            Assert.Equal("org.keycloak.keys.KeyProvider", result.ProviderType);
        }
    }
}
