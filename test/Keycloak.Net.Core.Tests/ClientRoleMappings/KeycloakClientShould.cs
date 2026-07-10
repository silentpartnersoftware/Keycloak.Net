using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetClientRoleMappingsForGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetClientRoleMappingsForGroupAsync(realm, groupId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-group-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableClientRoleMappingsForGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetAvailableClientRoleMappingsForGroupAsync(realm, groupId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-group-available"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetEffectiveClientRoleMappingsForGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetEffectiveClientRoleMappingsForGroupAsync(realm, groupId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-group-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetClientRoleMappingsForUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();
            var clientUuid = await _fixture.UserClientUuidAsync();

            var result = await _client.GetClientRoleMappingsForUserAsync(realm, userId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-user-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableClientRoleMappingsForUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();
            var clientUuid = await _fixture.UserClientUuidAsync();

            var result = await _client.GetAvailableClientRoleMappingsForUserAsync(realm, userId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-user-available"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetEffectiveClientRoleMappingsForUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();
            var clientUuid = await _fixture.UserClientUuidAsync();

            var result = await _client.GetEffectiveClientRoleMappingsForUserAsync(realm, userId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-user-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }
    }
}
