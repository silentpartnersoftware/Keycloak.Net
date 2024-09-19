namespace Keycloak.Net.Models.Root;

public class ConnectionsJpa
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ConnectionsJpaProviders Providers { get; set; }
}