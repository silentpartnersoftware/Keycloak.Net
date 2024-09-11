using Keycloak.Net.Models.Roles;

namespace Keycloak.Net.Models.Common;

public class ClientRoleMapping
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("client")]
	public string Client { get; set; }
	[JsonPropertyName("mappings")]
	public List<Role> Mappings { get; set; }
}