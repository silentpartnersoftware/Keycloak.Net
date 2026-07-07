namespace Keycloak.Net.Models.Users;

public class SocialLink
{
	[JsonPropertyName("socialProvider")]
	public string? SocialProvider { get; set; }

	[JsonPropertyName("socialUserId")]
	public string? SocialUserId { get; set; }

	[JsonPropertyName("socialUsername")]
	public string? SocialUsername { get; set; }
}
