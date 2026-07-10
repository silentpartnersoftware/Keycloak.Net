using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetScopeMappingsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();

            var result = await _client.GetScopeMappingsAsync(realm, clientScopeId);
            string[] expectedRealmRoleNames = ["keycloak-net-group-realm-mapped"];
            string[] expectedClientRoleNames = ["keycloak-net-group-mapped"];

            Assert.Equivalent(expectedRealmRoleNames, result.RealmMappings.Select(x => x.Name));
            Assert.True(result.ClientMappings.TryGetValue("keycloak-net-fixture-group-client", out var clientMapping));
            Assert.Equivalent(expectedClientRoleNames, clientMapping.Mappings.Select(x => x.Name));
        }

        [Fact]
        public async Task GetClientRolesForClientScopeAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetClientRolesForClientScopeAsync(realm, clientScopeId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-group-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableClientRolesForClientScopeAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetAvailableClientRolesForClientScopeAsync(realm, clientScopeId, clientUuid);
            var roleNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("keycloak-net-group-available", roleNames);
            Assert.DoesNotContain("keycloak-net-group-mapped", roleNames);
        }

        [Fact]
        public async Task GetEffectiveClientRolesForClientScopeAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetEffectiveClientRolesForClientScopeAsync(realm, clientScopeId, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-group-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetRealmRolesForClientScopeAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();

            var result = await _client.GetRealmRolesForClientScopeAsync(realm, clientScopeId);
            string[] expectedRoleNames = ["keycloak-net-group-realm-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableRealmRolesForClientScopeAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();

            var result = await _client.GetAvailableRealmRolesForClientScopeAsync(realm, clientScopeId);
            var roleNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("keycloak-net-realm-available", roleNames);
            Assert.DoesNotContain("keycloak-net-group-realm-mapped", roleNames);
        }

        [Fact]
        public async Task GetEffectiveRealmRolesForClientScopeAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();

            var result = await _client.GetEffectiveRealmRolesForClientScopeAsync(realm, clientScopeId);
            string[] expectedRoleNames = ["keycloak-net-group-realm-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetScopeMappingsForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetScopeMappingsForClientAsync(realm, clientUuid);
            string[] expectedRealmRoleNames = ["keycloak-net-user-realm-mapped"];
            string[] expectedClientRoleNames = ["keycloak-net-user-mapped"];

            Assert.Equivalent(expectedRealmRoleNames, result.RealmMappings.Select(x => x.Name));
            Assert.True(result.ClientMappings.TryGetValue("keycloak-net-fixture-user-client", out var clientMapping));
            Assert.Equivalent(expectedClientRoleNames, clientMapping.Mappings.Select(x => x.Name));
        }

        [Fact]
        public async Task GetClientRolesScopeMappingsForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();
            var scopeClientUuid = await _fixture.UserClientUuidAsync();

            var result = await _client.GetClientRolesScopeMappingsForClientAsync(realm, clientUuid, scopeClientUuid);
            string[] expectedRoleNames = ["keycloak-net-user-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableClientRolesForClientScopeForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();
            var scopeClientUuid = await _fixture.UserClientUuidAsync();

            var result = await _client.GetAvailableClientRolesForClientScopeForClientAsync(realm, clientUuid, scopeClientUuid);
            var roleNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("keycloak-net-user-available", roleNames);
            Assert.DoesNotContain("keycloak-net-user-mapped", roleNames);
        }

        [Fact]
        public async Task GetEffectiveClientRolesForClientScopeForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();
            var scopeClientUuid = await _fixture.UserClientUuidAsync();

            var result = await _client.GetEffectiveClientRolesForClientScopeForClientAsync(realm, clientUuid, scopeClientUuid);
            string[] expectedRoleNames = ["keycloak-net-user-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetRealmRolesScopeMappingsForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetRealmRolesScopeMappingsForClientAsync(realm, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-user-realm-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }

        [Fact]
        public async Task GetAvailableRealmRolesForClientScopeForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetAvailableRealmRolesForClientScopeForClientAsync(realm, clientUuid);
            var roleNames = result.Select(x => x.Name).ToArray();

            Assert.Contains("keycloak-net-realm-available", roleNames);
            Assert.DoesNotContain("keycloak-net-user-realm-mapped", roleNames);
        }

        [Fact]
        public async Task GetEffectiveRealmRolesForClientScopeForClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetEffectiveRealmRolesForClientScopeForClientAsync(realm, clientUuid);
            string[] expectedRoleNames = ["keycloak-net-user-realm-mapped"];

            Assert.Equivalent(expectedRoleNames, result.Select(x => x.Name));
        }
    }
}
