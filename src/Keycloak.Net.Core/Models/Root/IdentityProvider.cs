namespace Keycloak.Net.Models.Root;

public class IdentityProvider
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public IdentityProviderProviders Providers { get; set; }
}