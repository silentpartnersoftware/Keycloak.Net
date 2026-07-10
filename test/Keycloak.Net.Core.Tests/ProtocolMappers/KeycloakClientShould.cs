using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Keycloak.Net.Tests
{
    public partial class KeycloakClientShould
    {
        [Fact]
        public async Task GetProtocolMappersAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();
            var protocolMapperId = await _fixture.ProtocolMapperIdAsync();

            var result = await _client.GetProtocolMappersAsync(realm, clientScopeId);

            var protocolMapper = Assert.Single(result);
            Assert.Equal(protocolMapperId, protocolMapper.Id);
            Assert.Equal("keycloak-net-fixture-protocol-mapper", protocolMapper.Name);
            Assert.Equal("openid-connect", protocolMapper.Protocol);
            Assert.Equal("oidc-hardcoded-claim-mapper", protocolMapper._ProtocolMapper);
        }

        [Fact]
        public async Task GetProtocolMapperAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();
            var protocolMapperId = await _fixture.ProtocolMapperIdAsync();

            var result = await _client.GetProtocolMapperAsync(realm, clientScopeId, protocolMapperId);

            Assert.Equal(protocolMapperId, result.Id);
            Assert.Equal("keycloak-net-fixture-protocol-mapper", result.Name);
            Assert.Equal("openid-connect", result.Protocol);
            Assert.Equal("oidc-hardcoded-claim-mapper", result._ProtocolMapper);
            Assert.Equal("keycloak_net_fixture", result.Config["claim.name"]);
            Assert.Equal("phase1", result.Config["claim.value"]);
        }

        [Fact]
        public async Task GetProtocolMappersByNameAsync()
        {
            var realm = KeycloakTestFixture.Realm;
            var clientScopeId = await _fixture.ClientScopeIdAsync();
            var protocolMapperId = await _fixture.ProtocolMapperIdAsync();

            var result = await _client.GetProtocolMappersByNameAsync(realm, clientScopeId, "openid-connect");

            var protocolMapper = Assert.Single(result);
            Assert.Equal(protocolMapperId, protocolMapper.Id);
            Assert.Equal("keycloak-net-fixture-protocol-mapper", protocolMapper.Name);
            Assert.Equal("openid-connect", protocolMapper.Protocol);
            Assert.Equal("oidc-hardcoded-claim-mapper", protocolMapper._ProtocolMapper);
        }
    }
}
