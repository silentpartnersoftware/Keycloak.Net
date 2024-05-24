using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Theory]
        [InlineData("master")]
        public async Task GetScopeMappingsAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetScopeMappingsAsync(realm, clientScopeId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetClientRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var clients = await _client.GetClientsAsync(realm);
                string clientId = clients.FirstOrDefault()?.Id;
                if (clientId != null)
                {
                    var result = await _client.GetClientRolesForClientScopeAsync(realm, clientScopeId, clientId);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableClientRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var clients = await _client.GetClientsAsync(realm);
                string clientId = clients.FirstOrDefault()?.Id;
                if (clientId != null)
                {
                    var result = await _client.GetAvailableClientRolesForClientScopeAsync(realm, clientScopeId, clientId);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveClientRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var clients = await _client.GetClientsAsync(realm);
                string clientId = clients.FirstOrDefault()?.Id;
                if (clientId != null)
                {
                    var result = await _client.GetEffectiveClientRolesForClientScopeAsync(realm, clientScopeId, clientId);
                    Assert.NotNull(result);
                }
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetRealmRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetRealmRolesForClientScopeAsync(realm, clientScopeId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableRealmRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetAvailableRealmRolesForClientScopeAsync(realm, clientScopeId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveRealmRolesForClientScopeAsync(string realm)
        {
            var clientScopes = await _client.GetClientScopesAsync(realm);
            string clientScopeId = clientScopes.FirstOrDefault()?.Id;
            if (clientScopeId != null)
            {
                var result = await _client.GetEffectiveRealmRolesForClientScopeAsync(realm, clientScopeId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetScopeMappingsForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetScopeMappingsForClientAsync(realm, clientId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetClientRolesScopeMappingsForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetClientRolesScopeMappingsForClientAsync(realm, clientId, clientId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableClientRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetAvailableClientRolesForClientScopeForClientAsync(realm, clientId, clientId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveClientRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetEffectiveClientRolesForClientScopeForClientAsync(realm, clientId, clientId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetRealmRolesScopeMappingsForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetRealmRolesScopeMappingsForClientAsync(realm, clientId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetAvailableRealmRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetAvailableRealmRolesForClientScopeForClientAsync(realm, clientId);
                Assert.NotNull(result);
            }
        }

        [Theory]
        [InlineData("master")]
        public async Task GetEffectiveRealmRolesForClientScopeForClientAsync(string realm)
        {
            var clients = await _client.GetClientsAsync(realm);
            string clientId = clients.FirstOrDefault()?.Id;
            if (clientId != null)
            {
                var result = await _client.GetEffectiveRealmRolesForClientScopeForClientAsync(realm, clientId);
                Assert.NotNull(result);
            }
        }
    }
}
