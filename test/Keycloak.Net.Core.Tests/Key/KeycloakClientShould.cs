using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetKeysAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetKeysAsync(realm);
            var algorithms = result.Keys.Select(x => x.Algorithm).ToArray();

            Assert.NotNull(result.Active.Rs256);
            Assert.Contains("RS256", algorithms);
            Assert.Contains("AES", algorithms);
        }
    }
}
