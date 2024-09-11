namespace Keycloak.Net.Models.AuthorizationScopes;

public class AuthorizationScope
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("displayName")]
	public string DisplayName { get; set; }
}