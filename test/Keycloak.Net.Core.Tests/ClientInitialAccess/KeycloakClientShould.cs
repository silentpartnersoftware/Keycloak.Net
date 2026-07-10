using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetClientInitialAccessAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetClientInitialAccessAsync(realm);

            Assert.Empty(result);
        }
    }
}
