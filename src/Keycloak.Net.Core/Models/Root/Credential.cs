namespace Keycloak.Net.Models.Root;

public class Credential
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public CredentialProviders Providers { get; set; }
}