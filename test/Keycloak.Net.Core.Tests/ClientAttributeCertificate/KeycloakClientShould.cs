using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetKeyInfoAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetKeyInfoAsync(realm, clientUuid, "jwt.credential");

            Assert.Null(result.Kid);
            Assert.Null(result._Certificate);
        }
    }
}
