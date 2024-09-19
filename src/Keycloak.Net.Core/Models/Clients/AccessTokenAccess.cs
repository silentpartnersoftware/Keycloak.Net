namespace Keycloak.Net.Models.Clients;

public class AccessTokenAccess
{
	[JsonPropertyName("roles")]
	public IEnumerable<string> Roles { get; set; }
	[JsonPropertyName("verify_caller")]
	public bool? VerifyCaller { get; set; }
}