using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("Insurance")]
        public async Task GetUserCredentialsAsync(string realm)
        {
            var users = await _client.GetUsersAsync(realm);
            string userId = users.FirstOrDefault()?.Id;
            if (userId != null)
            {
                var result = await _client.GetUserCredentialsAsync(realm, userId);
                Assert.NotNull(result);
            }
        }
    }
}
