using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetRealmsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRealmsAsync(realm);

            Assert.Contains(result, x => x._Realm == realm);
        }

        [Fact]
        public async Task GetRealmAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRealmAsync(realm);

            Assert.Equal(realm, result._Realm);
            Assert.True(result.Enabled);
            Assert.False(result.RegistrationAllowed);
        }

        [Fact]
        public async Task GetAdminEventsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetAdminEventsAsync(realm);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetClientSessionStatsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetClientSessionStatsAsync(realm);

            var stats = Assert.Single(result);
            Assert.Equal("admin-cli", stats["clientId"]?.ToString());
            Assert.True(int.Parse(stats["active"]!.ToString()!) >= 0);
            Assert.True(int.Parse(stats["offline"]!.ToString()!) >= 0);
        }

        [Fact]
        public async Task GetRealmDefaultClientScopesAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRealmDefaultClientScopesAsync(realm);
            string[] expectedScopeNames = ["role_list", "saml_organization", "AuthnContextClassRef", "profile", "email", "roles", "web-origins", "acr", "basic"];

            Assert.Equivalent(expectedScopeNames, result.Select(x => x.Name), strict: true);
        }

        [Fact]
        public async Task GetRealmGroupHierarchyAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var defaultGroupId = await _fixture.DefaultGroupIdAsync();

            var result = await _client.GetRealmGroupHierarchyAsync(realm);

            var group = Assert.Single(result);
            Assert.Equal(defaultGroupId, group.Id);
            Assert.Equal("keycloak-net-fixture-default-group", group.Name);
            Assert.Equal("/keycloak-net-fixture-default-group", group.Path);
        }

        [Fact]
        public async Task GetRealmOptionalClientScopesAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRealmOptionalClientScopesAsync(realm);
            string[] expectedScopeNames = ["offline_access", "address", "phone", "microprofile-jwt", "organization"];

            Assert.Equivalent(expectedScopeNames, result.Select(x => x.Name), strict: true);
        }

        [Fact]
        public async Task GetEventsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetEventsAsync(realm);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetRealmEventsProviderConfigurationAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRealmEventsProviderConfigurationAsync(realm);

            Assert.False(result.EventsEnabled);
            Assert.False(result.AdminEventsEnabled);
            Assert.False(result.AdminEventsDetailsEnabled);
            Assert.Contains("jboss-logging", result.EventsListeners);
            Assert.Contains("LOGIN", result.EnabledEventTypes);
        }

        [Fact]
        public async Task GetRealmGroupByPathAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var defaultGroupId = await _fixture.DefaultGroupIdAsync();

            var result = await _client.GetRealmGroupByPathAsync(realm, KeycloakTestFixture.DefaultGroupPath);

            Assert.Equal(defaultGroupId, result.Id);
            Assert.Equal("keycloak-net-fixture-default-group", result.Name);
            Assert.Equal("/keycloak-net-fixture-default-group", result.Path);
        }

        [SkippableFact]
        public async Task GetRealmUsersManagementPermissionsAsync()
        {
            Skip.IfNot(IsServerFeatureEnabled("ADMIN_FINE_GRAINED_AUTHZ"), "Requires Keycloak feature ADMIN_FINE_GRAINED_AUTHZ (v1) to be enabled.");
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRealmUsersManagementPermissionsAsync(realm);

            Assert.False(result.Enabled);
        }
    }
}
