namespace Keycloak.Net.Models.ClientInitialAccess;

public class ClientInitialAccessCreatePresentation
{
	[JsonPropertyName("count")]
	public int? Count { get; set; }
	[JsonPropertyName("expiration")]
	public int? Expiration { get; set; }
}