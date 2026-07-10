using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact(Skip = "Requires an LDAP/user-storage provider test server to be meaningfully tested.")]
        public async Task TriggerUserSynchronizationAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            string storageProviderId = "";
            var result = await _client.TriggerUserSynchronizationAsync(realm, storageProviderId, UserSyncActions.Full);
            Assert.NotNull(result);
        }

        [Fact(Skip = "Requires an LDAP/user-storage provider test server to be meaningfully tested.")]
        public async Task TriggerLdapMapperSynchronizationAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            string storageProviderId = "";
            string mapperId = "";
            var result = await _client.TriggerLdapMapperSynchronizationAsync(realm, storageProviderId, mapperId, LdapMapperSyncActions.KeycloakToFed);
            Assert.NotNull(result);
        }
    }
}
