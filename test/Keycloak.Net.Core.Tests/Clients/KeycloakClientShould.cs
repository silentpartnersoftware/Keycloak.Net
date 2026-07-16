using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetClientsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var fixtureClientUuid = await _fixture.FixtureClientUuidAsync();
            var groupClientUuid = await _fixture.GroupClientUuidAsync();
            var userClientUuid = await _fixture.UserClientUuidAsync();

            var result = await _client.GetClientsAsync(realm);

            Assert.Equal(fixtureClientUuid, result.Single(x => x.ClientId == KeycloakTestFixture.FixtureClientId).Id);
            Assert.Equal(groupClientUuid, result.Single(x => x.ClientId == KeycloakTestFixture.GroupClientId).Id);
            Assert.Equal(userClientUuid, result.Single(x => x.ClientId == KeycloakTestFixture.UserClientId).Id);
        }

        [Fact]
        public async Task GetClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetClientAsync(realm, clientUuid);

            Assert.Equal(clientUuid, result.Id);
            Assert.Equal("keycloak-net-fixture-client", result.ClientId);
            Assert.True(result.Enabled);
            Assert.Equal("openid-connect", result.Protocol);
        }

        [Fact]
        public async Task GenerateClientSecretAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GenerateClientSecretAsync(realm, clientUuid);

            Assert.Equal("secret", result.Type);
            Assert.False(string.IsNullOrWhiteSpace(result.Value));
        }

        [Fact]
        public async Task GetClientSecretAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetClientSecretAsync(realm, clientUuid);

            Assert.Equal("secret", result.Type);
            Assert.False(string.IsNullOrWhiteSpace(result.Value));
        }

        [Fact]
        public async Task GetDefaultClientScopesAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetDefaultClientScopesAsync(realm, clientUuid);
            string[] expectedScopeNames = ["web-origins", "service_account", "acr", "profile", "roles", "basic", "email"];

            Assert.Equivalent(expectedScopeNames, result.Select(x => x.Name), strict: true);
        }

        [Fact(Skip = "Not working yet")]
        public async Task GenerateClientExampleAccessTokenAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GenerateClientExampleAccessTokenAsync(realm, clientUuid);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetProtocolMappersInTokenGenerationAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetProtocolMappersInTokenGenerationAsync(realm, clientUuid);
            var mapperNames = result.Select(x => x.MapperName).ToArray();

            Assert.Contains("Client IP Address", mapperNames);
            Assert.Contains("Client Host", mapperNames);
            Assert.Contains("Client ID", mapperNames);
        }

        [Fact]
        public async Task GetClientGrantedScopeMappingsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var realmRoles = await _client.GetClientGrantedScopeMappingsAsync(realm, clientUuid, realm);
            var clientRoles = await _client.GetClientGrantedScopeMappingsAsync(realm, clientUuid, clientUuid);

            Assert.Contains(realmRoles, x => x.Name == "default-roles-keycloak-net-fixture");
            Assert.Contains(realmRoles, x => x.Name == "offline_access");
            Assert.Empty(clientRoles);
        }

        [Fact]
        public async Task GetClientNotGrantedScopeMappingsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var realmRoles = await _client.GetClientNotGrantedScopeMappingsAsync(realm, clientUuid, realm);
            var clientRoles = await _client.GetClientNotGrantedScopeMappingsAsync(realm, clientUuid, clientUuid);

            Assert.Empty(realmRoles);
            Assert.Empty(clientRoles);
        }

        [Fact]
        public async Task GetClientProviderAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetClientProviderAsync(realm, clientUuid, "keycloak-oidc-keycloak-json");

            Assert.Contains("\"realm\" : \"keycloak-net-fixture\"", result);
            Assert.Contains("\"resource\" : \"keycloak-net-fixture-client\"", result);
            Assert.Contains("\"credentials\"", result);
        }

        [SkippableFact]
        public async Task GetClientAuthorizationPermissionsInitializedAsync()
        {
            Skip.IfNot(IsServerFeatureEnabled("ADMIN_FINE_GRAINED_AUTHZ"), "Requires Keycloak feature ADMIN_FINE_GRAINED_AUTHZ (v1) to be enabled.");
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.GroupClientUuidAsync();

            var result = await _client.GetClientAuthorizationPermissionsInitializedAsync(realm, clientUuid);

            Assert.False(result.Enabled);
        }

        [Fact]
        public async Task GetClientOfflineSessionCountAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetClientOfflineSessionCountAsync(realm, clientUuid);

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task GetClientOfflineSessionsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetClientOfflineSessionsAsync(realm, clientUuid);

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetOptionalClientScopesAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetOptionalClientScopesAsync(realm, clientUuid);
            string[] expectedScopeNames = ["address", "phone", "offline_access", "organization", "microprofile-jwt"];

            Assert.Equivalent(expectedScopeNames, result.Select(x => x.Name), strict: true);
        }

        [Fact]
        public async Task GenerateClientRegistrationAccessTokenAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GenerateClientRegistrationAccessTokenAsync(realm, clientUuid);

            Assert.Equal(clientUuid, result.Id);
            Assert.Equal("keycloak-net-fixture-client", result.ClientId);
            Assert.False(string.IsNullOrWhiteSpace(result.Secret));
        }

        [Fact]
        public async Task GetUserForServiceAccountAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetUserForServiceAccountAsync(realm, clientUuid);

            Assert.Equal("service-account-keycloak-net-fixture-client", result.UserName);
            Assert.True(result.Enabled);
        }

        [Fact]
        public async Task GetClientSessionCountAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetClientSessionCountAsync(realm, clientUuid);

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task TestClientClusterNodesAvailableAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.TestClientClusterNodesAvailableAsync(realm, clientUuid);

            Assert.Null(result.FailedRequests);
            Assert.Null(result.SuccessRequests);
        }

        [Fact]
        public async Task GetClientUserSessionsAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientUuid = await _fixture.FixtureClientUuidAsync();

            var result = await _client.GetClientUserSessionsAsync(realm, clientUuid);

            Assert.Empty(result);
        }

        [Fact(Skip = "Pending to figure out test configuration")]
        public async Task GetResourcesOwnedByClientAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetResourcesOwnedByClientAsync(realm, KeycloakTestFixture.FixtureClientId);

            Assert.NotNull(result);
        }
    }
}
