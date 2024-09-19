using Keycloak.Net.Models.Roles;

namespace Keycloak.Net.Models.Common;

public class Mapping
{
	[JsonPropertyName("clientMappings")]
	public IDictionary<string, ClientRoleMapping> ClientMappings { get; set; }
	[JsonPropertyName("realmMappings")]
	public IEnumerable<Role> RealmMappings { get; set; }
}