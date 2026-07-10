using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetUserNameStatusInBruteForceDetectionAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUserNameStatusInBruteForceDetectionAsync(realm, userId);

            Assert.Equal(0, result.NumFailures);
            Assert.False(result.Disabled);
            Assert.Equal(0, result.LastFailure);
            Assert.Equal("n/a", result.LastIpFailure);
        }
    }
}
