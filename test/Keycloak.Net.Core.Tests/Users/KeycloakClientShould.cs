using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetUsersAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUsersAsync(realm, username: KeycloakTestFixture.UserName, exact: true);
            string[] expectedUserNames = ["keycloak-net-fixture-user"];

            Assert.Equivalent(expectedUserNames, result.Select(x => x.UserName), strict: true);
            Assert.Equal(userId, result.Single().Id);
        }

        [Fact]
        public async Task GetUsersCountAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetUsersCountAsync(realm, username: KeycloakTestFixture.UserName);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUserAsync(realm, userId);

            Assert.Equal(userId, result.Id);
            Assert.Equal("keycloak-net-fixture-user", result.UserName);
            Assert.True(result.Enabled);
        }

        [Fact]
        public async Task GetUserSocialLoginsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUserSocialLoginsAsync(realm, userId);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetUserGroupsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUserGroupsAsync(realm, userId);
            string[] expectedGroupNames = ["keycloak-net-fixture-group"];

            Assert.Equivalent(expectedGroupNames, result.Select(x => x.Name), strict: true);
            Assert.Equal(groupId, result.Single().Id);
        }

        [Fact]
        public async Task GetUserGroupsCountAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUserGroupsCountAsync(realm, userId);

            Assert.Equal(1, result);
        }

        [Fact]
        public async Task GetUserSessionsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUserSessionsAsync(realm, userId);

            Assert.Empty(result);
        }
    }
}
