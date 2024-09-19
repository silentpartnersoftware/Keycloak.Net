namespace Keycloak.Net.Models.Root;

public class ConnectionsJpaUpdaterProviders
{
	[JsonPropertyName("liquibase")]
	public HasOrder Liquibase { get; set; }
}