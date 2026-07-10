using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetRetrieveProvidersBasePathAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRetrieveProvidersBasePathAsync(realm);
            var providerIds = result.Select(x => x.Id).ToArray();

            Assert.Contains("allowed-client-templates", providerIds);
            Assert.Contains("max-clients", providerIds);
        }
    }
}
