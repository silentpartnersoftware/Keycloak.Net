namespace Keycloak.Net.Models.Root;

public class ClientRegistrationPolicy
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ClientRegistrationPolicyProviders Providers { get; set; }
}