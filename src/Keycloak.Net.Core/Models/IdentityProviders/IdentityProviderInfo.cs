namespace Keycloak.Net.Models.IdentityProviders;

public class IdentityProviderInfo
{
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("id")]
	public string Id { get; set; }
}