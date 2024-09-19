namespace Keycloak.Net.Models.Clients;

public class Permission : Resource
{
	[JsonPropertyName("claims")]
	public IDictionary<string, object> Claims { get; set; }
}