using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetIdentityProviderInstancesAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetIdentityProviderInstancesAsync(realm);
            string[] expectedAliases = ["keycloak-net-fixture-oidc"];

            Assert.Equivalent(expectedAliases, result.Select(x => x.Alias), strict: true);
        }

        [Fact]
        public async Task GetIdentityProviderAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var identityProviderAlias = KeycloakTestFixture.IdentityProviderAlias;

            var result = await _client.GetIdentityProviderAsync(realm, identityProviderAlias);

            Assert.Equal(identityProviderAlias, result.Alias);
            Assert.Equal("oidc", result.ProviderId);
            Assert.True(result.Enabled);
            Assert.True(result.LinkOnly);
        }

        //[Theory]
        //[InlineData("keycloak-net-fixture")]
        //public async Task GetIdentityProviderTokenAsync(string realm)
        //{
        //    var token = await _client.GetIdentityProviderTokenAsync(realm).ConfigureAwait(false);
        //    Assert.NotNull(token);
        //}

        [SkippableFact]
        public async Task GetIdentityProviderAuthorizationPermissionsInitializedAsync()
        {
            Skip.IfNot(IsServerFeatureEnabled("ADMIN_FINE_GRAINED_AUTHZ"), "Requires Keycloak feature ADMIN_FINE_GRAINED_AUTHZ (v1) to be enabled.");
            var realm = KeycloakTestFixture.Realm;
            var identityProviderAlias = KeycloakTestFixture.IdentityProviderAlias;

            var result = await _client.GetIdentityProviderAuthorizationPermissionsInitializedAsync(realm, identityProviderAlias);

            Assert.False(result.Enabled);
        }

        [Fact]
        public async Task GetIdentityProviderMapperTypesAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var identityProviderAlias = KeycloakTestFixture.IdentityProviderAlias;

            var result = await _client.GetIdentityProviderMapperTypesAsync(realm, identityProviderAlias);

            Assert.Contains("oidc-user-attribute-idp-mapper", result.Keys);
        }

        [Fact]
        public async Task GetIdentityProviderMappersAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var identityProviderAlias = KeycloakTestFixture.IdentityProviderAlias;
            var mapperId = await _fixture.IdentityProviderMapperIdAsync();

            var result = await _client.GetIdentityProviderMappersAsync(realm, identityProviderAlias);
            string[] expectedMapperNames = ["keycloak-net-fixture-idp-mapper"];

            Assert.Equivalent(expectedMapperNames, result.Select(x => x.Name), strict: true);
            Assert.Equal(mapperId, result.Single().Id);
        }

        [Fact]
        public async Task GetIdentityProviderMapperByIdAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var identityProviderAlias = KeycloakTestFixture.IdentityProviderAlias;
            var mapperId = await _fixture.IdentityProviderMapperIdAsync();

            var result = await _client.GetIdentityProviderMapperByIdAsync(realm, identityProviderAlias, mapperId);

            Assert.Equal(mapperId, result.Id);
            Assert.Equal("keycloak-net-fixture-idp-mapper", result.Name);
            Assert.Equal("oidc-user-attribute-idp-mapper", result._IdentityProviderMapper);
            Assert.Equal("fixture_claim", ((JsonElement)result.Config["claim"]).GetString());
            Assert.Equal("fixtureAttribute", ((JsonElement)result.Config["user.attribute"]).GetString());
        }

        [Fact]
        public async Task GetIdentityProviderByProviderIdAsync()
        {
            var realm = KeycloakTestFixture.Realm;

            var result = await _client.GetIdentityProviderByProviderIdAsync(realm, "oidc");

            Assert.Equal("oidc", result.Id);
            Assert.Equal("OpenID Connect v1.0", result.Name);
        }
    }
}
