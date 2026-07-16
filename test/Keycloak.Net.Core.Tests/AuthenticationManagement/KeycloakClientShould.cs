using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetAuthenticatorProvidersAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetAuthenticatorProvidersAsync(realm);
            var providerIds = result.Select(x => x["id"].ToString()).ToArray();

            Assert.Contains("auth-cookie", providerIds);
            Assert.Contains("auth-password-form", providerIds);
        }

        [Fact]
        public async Task GetClientAuthenticatorProvidersAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetClientAuthenticatorProvidersAsync(realm);
            var providerIds = result.Select(x => x["id"].ToString()).ToArray();

            Assert.Contains("client-secret", providerIds);
            Assert.Contains("client-jwt", providerIds);
        }

        [Fact]
        public async Task GetAuthenticatorProviderConfigurationDescriptionAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetAuthenticatorProviderConfigurationDescriptionAsync(realm, "auth-cookie");

            Assert.Equal("auth-cookie", result.ProviderId);
            Assert.Equal("Cookie", result.Name);
        }

        [Fact(Skip = "Requires a configured authenticator configuration ID to be meaningfully tested.")]
        public async Task GetAuthenticatorConfigurationAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            string configurationId = ""; //TODO
            if (configurationId != null)
            {
                var result = await _client.GetAuthenticatorConfigurationAsync(realm, configurationId);
                Assert.NotNull(result);
            }
        }

        [Fact]
        public async Task GetAuthenticationExecutionAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var executions = await _client.GetAuthenticationFlowExecutionsAsync(realm, "browser");
            var executionId = executions.Single(x => x.ProviderId == "auth-cookie").Id;

            var result = await _client.GetAuthenticationExecutionAsync(realm, executionId);

            Assert.Equal(executionId, result.Id);
            Assert.Equal("auth-cookie", result.Authenticator);
            Assert.Equal("ALTERNATIVE", result.Requirement);
        }

        [Fact]
        public async Task GetAuthenticationFlowsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetAuthenticationFlowsAsync(realm);
            var aliases = result.Select(x => x.Alias).ToArray();

            Assert.Contains("browser", aliases);
            Assert.Contains("direct grant", aliases);
        }

        [Fact]
        public async Task GetAuthenticationFlowExecutionsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetAuthenticationFlowExecutionsAsync(realm, "browser");
            var providerIds = result.Select(x => x.ProviderId).ToArray();

            Assert.Contains("auth-cookie", providerIds);
            Assert.Contains("auth-username-password-form", providerIds);
        }

        [Fact]
        public async Task GetAuthenticationFlowByIdAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var flows = await _client.GetAuthenticationFlowsAsync(realm);
            var flowId = flows.Single(x => x.Alias == "browser").Id;

            var result = await _client.GetAuthenticationFlowByIdAsync(realm, flowId);

            Assert.Equal(flowId, result.Id);
            Assert.Equal("browser", result.Alias);
            Assert.Equal("basic-flow", result.ProviderId);
        }

        [Fact]
        public async Task GetFormActionProvidersAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetFormActionProvidersAsync(realm);
            var providerIds = result.Select(x => x["id"].ToString()).ToArray();

            Assert.Contains("registration-user-creation", providerIds);
        }

        [Fact]
        public async Task GetFormProvidersAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetFormProvidersAsync(realm);
            var providerIds = result.Select(x => x["id"].ToString()).ToArray();

            Assert.Contains("registration-page-form", providerIds);
        }

        [Fact]
        public async Task GetConfigurationDescriptionsForAllClientsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetConfigurationDescriptionsForAllClientsAsync(realm);

            Assert.Contains("client-secret", result.Keys);
            Assert.Contains("client-jwt", result.Keys);
        }

        [Fact]
        public async Task GetRequiredActionsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRequiredActionsAsync(realm);
            var aliases = result.Select(x => x.Alias).ToArray();

            Assert.Contains("UPDATE_PASSWORD", aliases);
            Assert.Contains("VERIFY_EMAIL", aliases);
        }

        [Fact]
        public async Task GetRequiredActionByAliasAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetRequiredActionByAliasAsync(realm, "UPDATE_PASSWORD");

            Assert.Equal("UPDATE_PASSWORD", result.Alias);
            Assert.True(result.Enabled);
        }

        [Fact]
        public async Task GetUnregisteredRequiredActionsAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetUnregisteredRequiredActionsAsync(realm);

            Assert.Empty(result);
        }
    }
}
