using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetRoleMappingsForGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetRoleMappingsForGroupAsync(realm, groupId);
            string[] expectedRealmRoleNames = ["keycloak-net-group-realm-mapped"];
            string[] expectedClientRoleNames = ["keycloak-net-group-mapped"];

            Assert.Equivalent(expectedRealmRoleNames, result.RealmMappings.Select(x => x.Name));
            Assert.True(result.ClientMappings.TryGetValue("keycloak-net-fixture-group-client", out var clientMapping));
            Assert.Equivalent(expectedClientRoleNames, clientMapping.Mappings.Select(x => x.Name));
        }

        [Fact]
        public async Task GetRealmRoleMappingsForGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetRealmRoleMappingsForGroupAsync(realm, groupId);
            string[] expectedRoleNames = ["keycloak-net-group-realm-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableRealmRoleMappingsForGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetAvailableRealmRoleMappingsForGroupAsync(realm, groupId);
            var roleNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("keycloak-net-realm-available", roleNames);
            Assert.DoesNotContain("keycloak-net-group-realm-mapped", roleNames);
        }

        [Fact]
        public async Task GetEffectiveRealmRoleMappingsForGroupAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetEffectiveRealmRoleMappingsForGroupAsync(realm, groupId);

            Assert.Contains(result, x => x.Name == "keycloak-net-group-realm-mapped");
        }

        [Fact]
        public async Task GetRoleMappingsForUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetRoleMappingsForUserAsync(realm, userId);
            string[] expectedRoleNames = ["keycloak-net-user-realm-mapped"];
            string[] expectedClientRoleNames = ["keycloak-net-user-mapped"];

            Assert.Equivalent(expectedRoleNames, result.RealmMappings.Select(x => x.Name));
            Assert.True(result.ClientMappings.TryGetValue("keycloak-net-fixture-user-client", out var clientMapping));
            Assert.Equivalent(expectedClientRoleNames, clientMapping.Mappings.Select(x => x.Name));
        }

        [Fact]
        public async Task GetRealmRoleMappingsForUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetRealmRoleMappingsForUserAsync(realm, userId);
            string[] expectedRoleNames = ["keycloak-net-user-realm-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableRealmRoleMappingsForUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetAvailableRealmRoleMappingsForUserAsync(realm, userId);
            var roleNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("keycloak-net-realm-available", roleNames);
            Assert.DoesNotContain("keycloak-net-user-realm-mapped", roleNames);
        }

        [Fact]
        public async Task GetEffectiveRealmRoleMappingsForUserAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetEffectiveRealmRoleMappingsForUserAsync(realm, userId);

            Assert.Contains(result, x => x.Name == "keycloak-net-user-realm-mapped");
        }
    }
}
