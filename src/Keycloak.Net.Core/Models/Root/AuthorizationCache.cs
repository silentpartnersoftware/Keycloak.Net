namespace Keycloak.Net.Models.Root;

public class AuthorizationCache
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public HasDefault Providers { get; set; }
}