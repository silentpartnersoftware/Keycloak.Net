using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetServerInfoAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetServerInfoAsync(realm);
            var enabledFeatures = result.Features.Where(x => x.Enabled).Select(x => x.Name).ToArray();

            Assert.Contains("ADMIN_FINE_GRAINED_AUTHZ", enabledFeatures);
            Assert.NotNull(result.SystemInfo);
        }

        [Fact]
        public async Task CorsPreflightAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            bool? result = await _client.CorsPreflightAsync(realm);

            Assert.True(result);
        }
    }
}
