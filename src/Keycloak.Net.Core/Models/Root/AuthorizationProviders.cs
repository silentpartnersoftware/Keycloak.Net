namespace Keycloak.Net.Models.Root;

public class AuthorizationProviders
{
	[JsonPropertyName("authorization")]
	public HasOrder Authorization { get; set; }
}