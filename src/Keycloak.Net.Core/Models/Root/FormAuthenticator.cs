namespace Keycloak.Net.Models.Root;

public class FormAuthenticator
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public FormAuthenticatorProviders Providers { get; set; }
}