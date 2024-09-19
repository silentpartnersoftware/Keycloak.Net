namespace Keycloak.Net.Models.Root;

public class AuthorizationPersister
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public AuthorizationPersisterProviders Providers { get; set; }
}