namespace Keycloak.Net.Models.AuthorizationResources;

public class AuthorizationResourceOwner
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
}