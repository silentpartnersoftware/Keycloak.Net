namespace Keycloak.Net.Models.Clients;

public class AccessTokenAuthorization
{
	[JsonPropertyName("permissions")]
	public IEnumerable<Permission> Permissions { get; set; }
}