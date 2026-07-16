using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetGroupHierarchyAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetGroupHierarchyAsync(realm, search: KeycloakTestFixture.GroupName);
            string[] expectedGroupNames = ["keycloak-net-fixture-group"];

            Assert.Equivalent(expectedGroupNames, result.Select(x => x.Name), strict: true);
            Assert.Equal(groupId, result.Single().Id);
        }

        [Fact]
        public async Task GetGroupsCountAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetGroupsCountAsync(realm, search: KeycloakTestFixture.GroupName);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetGroupAsync(realm, groupId);

            Assert.Equal(groupId, result.Id);
            Assert.Equal("keycloak-net-fixture-group", result.Name);
            Assert.Equal("/keycloak-net-fixture-group", result.Path);
        }

        [Fact]
        public async Task GetGroupClientAuthorizationPermissionsInitializedAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetGroupClientAuthorizationPermissionsInitializedAsync(realm, groupId);

            Assert.False(result.Enabled);
        }

        [Fact]
        public async Task GetGroupUsersAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetGroupUsersAsync(realm, groupId);
            string[] expectedUserNames = ["keycloak-net-fixture-user"];

            Assert.Equivalent(expectedUserNames, result.Select(x => x.UserName), strict: true);
            Assert.Equal(userId, result.Single().Id);
        }
    }
}
