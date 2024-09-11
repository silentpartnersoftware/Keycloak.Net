namespace Keycloak.Net.Models.Roles;

public class RoleComposite
{
	[JsonPropertyName("client")]
	public IDictionary<string, string> Client { get; set; }
	[JsonPropertyName("realm")]
	public IEnumerable<string> Realm { get; set; }
}