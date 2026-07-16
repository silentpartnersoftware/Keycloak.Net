using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetClientScopesAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();

            var result = await _client.GetClientScopesAsync(realm);
            var clientScope = result.Single(x => x.Name == KeycloakTestFixture.ClientScopeName);

            Assert.Equal(clientScopeId, clientScope.Id);
        }

        [Fact]
        public async Task GetClientScopeAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();

            var result = await _client.GetClientScopeAsync(realm, clientScopeId);

            Assert.Equal(clientScopeId, result.Id);
            Assert.Equal("keycloak-net-fixture-client-scope", result.Name);
            Assert.Equal("Fixture client scope for Keycloak.Net tests.", result.Description);
            Assert.Equal("openid-connect", result.Protocol);
        }
    }
}
