using Keycloak.Net.Models.Roles;

namespace Keycloak.Net.Models.RealmsAdmin;

public class Roles
{
	[JsonPropertyName("client")]
	public IDictionary<string, object> Client { get; set; }
	[JsonPropertyName("realm")]
	public IEnumerable<Role> Realm { get; set; }
}