namespace Keycloak.Net.Models.Root;

public class ConnectionsJpaProviders
{
	[JsonPropertyName("default")]
	public Default Default { get; set; }
}