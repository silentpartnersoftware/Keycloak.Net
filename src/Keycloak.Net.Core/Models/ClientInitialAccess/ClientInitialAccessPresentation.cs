namespace Keycloak.Net.Models.ClientInitialAccess;

public class ClientInitialAccessPresentation : ClientInitialAccessCreatePresentation
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("remainingCount")]
	public int? RemainingCount { get; set; }
	[JsonPropertyName("timestamp")]
	public int? Timestamp { get; set; }
	[JsonPropertyName("token")]
	public string Token { get; set; }
}