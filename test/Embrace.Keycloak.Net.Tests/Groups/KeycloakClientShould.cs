using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("master")]
        public async Task GetGroupHierarchyAsync(string realm)
        {
            var result = await _client.GetGroupsAsync(realm);
            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("master")]
        public async Task GetGroupsCountAsync(string realm)
        {
            int? result = await _client.GetGroupsCountAsync(realm);
            Assert.True(result >= 0);
        }

        [Theory]
        [InlineData("master")]
        public async Task GetGroupAsync(string realm)
        {
            var groups = await _client.GetGroupsAsync(realm);
            string groupId = groups.FirstOrDefault()?.Id;
            if (groupId != null)
            {
                var result = await _client.GetGroupAsync(realm, groupId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetGroupClientAuthorizationPermissionsInitializedAsync(string realm)
        {
            var groups = await _client.GetGroupsAsync(realm);
            string groupId = groups.FirstOrDefault()?.Id;
            if (groupId != null)
            {
                var result = await _client.GetGroupClientAuthorizationPermissionsInitializedAsync(realm, groupId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetGroupUsersAsync(string realm)
        {
            var groups = await _client.GetGroupsAsync(realm);
            string groupId = groups.FirstOrDefault()?.Id;
            if (groupId != null)
            {
                var result = await _client.GetGroupUsersAsync(realm, groupId);
                Assert.NotNull(result);
            }
        }
    }
}
