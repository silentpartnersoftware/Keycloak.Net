using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetRolesForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetRolesAsync(realm, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-group-mapped", "keycloak-net-group-available"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name), strict: true);
            Assert.All(result, x => Assert.Equal(clientUuid, x.ContainerId));
        }

        [Fact]
        public async Task GetRoleByNameForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetRoleByNameAsync(realm, clientUuid, KeycloakTestFixture.GroupClientRoleName);

            Assert.Equal("keycloak-net-group-mapped", result.Name);
            Assert.Equal(clientUuid, result.ContainerId);
            Assert.True(result.ClientRole);
        }

        [Fact]
        public async Task GetRoleCompositesForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetRoleCompositesAsync(realm, clientUuid, KeycloakTestFixture.GroupClientRoleName);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetApplicationRolesForCompositeForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetApplicationRolesForCompositeAsync(realm, clientUuid, KeycloakTestFixture.GroupClientRoleName, clientUuid);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetRealmRolesForCompositeForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetRealmRolesForCompositeAsync(realm, clientUuid, KeycloakTestFixture.GroupClientRoleName);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetGroupsWithRoleNameForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetGroupsWithRoleNameAsync(realm, clientUuid, KeycloakTestFixture.GroupClientRoleName);
            string[] expectedGroupNames = ["keycloak-net-fixture-group"];

            Assert.Equivalent(expectedGroupNames, result.Select(x => x.Name), strict: true);
            Assert.Equal(groupId, result.Single().Id);
        }

        [SkippableFact]
        public async Task GetRoleAuthorizationPermissionsInitializedForClientAsync()
        {
            Skip.IfNot(IsServerFeatureEnabled("ADMIN_FINE_GRAINED_AUTHZ"), "Requires Keycloak feature ADMIN_FINE_GRAINED_AUTHZ (v1) to be enabled.");
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetRoleAuthorizationPermissionsInitializedAsync(realm, clientUuid, KeycloakTestFixture.GroupClientRoleName);

            Assert.False(result.Enabled);
        }

        [Fact]
        public async Task GetUsersWithRoleNameForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.UserClientUuidAsync();
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUsersWithRoleNameAsync(realm, clientUuid, KeycloakTestFixture.UserClientRoleName);
            string[] expectedUserNames = ["keycloak-net-fixture-user"];

            Assert.Equivalent(expectedUserNames, result.Select(x => x.UserName), strict: true);
            Assert.Equal(userId, result.Single().Id);
        }

        [Fact]
        public async Task GetRolesForRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var roleId = await _fixture.RealmRoleIdAsync();

            var result = await _client.GetRolesAsync(realm, search: "keycloak-net-");
            var roleNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("keycloak-net-group-realm-mapped", roleNames);
            Assert.Contains("keycloak-net-user-realm-mapped", roleNames);
            Assert.Contains("keycloak-net-realm-available", roleNames);
            Assert.Equal(roleId, result.Single(x => x.Name == KeycloakTestFixture.RealmRoleName).Id);
        }

        [Fact]
        public async Task GetRoleByNameForRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var roleId = await _fixture.RealmRoleIdAsync();

            var result = await _client.GetRoleByNameAsync(realm, KeycloakTestFixture.RealmRoleName);

            Assert.Equal(roleId, result.Id);
            Assert.Equal("keycloak-net-realm-available", result.Name);
            Assert.False(result.ClientRole);
        }

        [Fact]
        public async Task GetRoleCompositesForRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRoleCompositesAsync(realm, KeycloakTestFixture.RealmRoleName);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetApplicationRolesForCompositeForRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetApplicationRolesForCompositeAsync(realm, KeycloakTestFixture.RealmRoleName, clientUuid);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetRealmRolesForCompositeForRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRealmRolesForCompositeAsync(realm, KeycloakTestFixture.RealmRoleName);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetGroupsWithRoleNameForRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var groupId = await _fixture.GroupIdAsync();

            var result = await _client.GetGroupsWithRoleNameAsync(realm, KeycloakTestFixture.GroupRealmRoleName);
            string[] expectedGroupNames = ["keycloak-net-fixture-group"];

            Assert.Equivalent(expectedGroupNames, result.Select(x => x.Name), strict: true);
            Assert.Equal(groupId, result.Single().Id);
        }

        [SkippableFact]
        public async Task GetRoleAuthorizationPermissionsInitializedForRealmAsync()
        {
            Skip.IfNot(IsServerFeatureEnabled("ADMIN_FINE_GRAINED_AUTHZ"), "Requires Keycloak feature ADMIN_FINE_GRAINED_AUTHZ (v1) to be enabled.");
            var realm = KeycloakTestFixture.Realm;
            var roleName = KeycloakTestFixture.RealmRoleName;

            var result = await _client.GetRoleAuthorizationPermissionsInitializedAsync(realm, roleName);

            Assert.False(result.Enabled);
        }

        [Fact]
        public async Task GetUsersWithRoleNameForRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var userId = await _fixture.UserIdAsync();

            var result = await _client.GetUsersWithRoleNameAsync(realm, KeycloakTestFixture.UserRealmRoleName);
            string[] expectedUserNames = ["keycloak-net-fixture-user"];

            Assert.Equivalent(expectedUserNames, result.Select(x => x.UserName), strict: true);
            Assert.Equal(userId, result.Single().Id);
        }
    }
}
