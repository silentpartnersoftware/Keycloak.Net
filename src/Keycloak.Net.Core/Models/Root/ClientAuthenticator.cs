namespace Keycloak.Net.Models.Root;

public class ClientAuthenticator
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ClientAuthenticatorProviders Providers { get; set; }
}