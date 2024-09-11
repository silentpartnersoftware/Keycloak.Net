namespace Keycloak.Net.Models.Root;

public class Oauth2TokenIntrospectionProviders
{
	[JsonPropertyName("access_token")]
	public HasOrder AccessToken { get; set; }

	[JsonPropertyName("refresh_token")]
	public HasOrder RefreshToken { get; set; }

	[JsonPropertyName("requesting_party_token")]
	public HasOrder RequestingPartyToken { get; set; }
}