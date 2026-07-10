using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetRoleByIdAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var roleId = await _fixture.RealmRoleIdAsync();

            var result = await _client.GetRoleByIdAsync(realm, roleId);

            Assert.Equal(roleId, result.Id);
            Assert.Equal("keycloak-net-realm-available", result.Name);
        }

        [Fact]
        public async Task GetRoleChildrenAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var roleId = await _fixture.RealmRoleIdAsync();

            var result = await _client.GetRoleChildrenAsync(realm, roleId);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetClientRolesForCompositeByIdAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var roleId = await _fixture.RealmRoleIdAsync();
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetClientRolesForCompositeByIdAsync(realm, roleId, clientUuid);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetRealmRolesForCompositeByIdAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var roleId = await _fixture.RealmRoleIdAsync();

            var result = await _client.GetRealmRolesForCompositeByIdAsync(realm, roleId);

            Assert.Empty(result);
        }

        [SkippableFact]
        public async Task GetRoleByIdAuthorizationPermissionsInitializedAsync()
        {
            Skip.IfNot(IsServerFeatureEnabled("ADMIN_FINE_GRAINED_AUTHZ"), "Requires Keycloak feature ADMIN_FINE_GRAINED_AUTHZ (v1) to be enabled.");
            var realm = KeycloakTestFixture.Realm;
            var roleId = await _fixture.RealmRoleIdAsync();

            var result = await _client.GetRoleByIdAuthorizationPermissionsInitializedAsync(realm, roleId);

            Assert.False(result.Enabled);
        }
    }
}
