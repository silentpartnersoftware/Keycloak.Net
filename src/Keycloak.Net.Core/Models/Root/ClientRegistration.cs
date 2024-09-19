namespace Keycloak.Net.Models.Root;

public class ClientRegistration
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ClientRegistrationProviders Providers { get; set; }
}