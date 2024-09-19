namespace Keycloak.Net.Models.IdentityProviders;

public class IdentityProviderToken
{
	[JsonPropertyName("access_token")]
	public string AccessToken { get; set; }

	[JsonPropertyName("token_type")]
	public string RequestingPartyToken { get; set; }

	[JsonPropertyName("expires_in")]
	public int ExpiresIn { get; set; }

	[JsonPropertyName("refresh_token")]
	public string RefreshToken { get; set; }

	[JsonPropertyName("scope")]
	public string Scope { get; set; }

	[JsonPropertyName("created_at")]
	public long CreatedAt { get; set; }
}