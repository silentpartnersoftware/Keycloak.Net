namespace Keycloak.Net.Models.Root;

public class CredentialProviders
{
	[JsonPropertyName("keycloak-otp")]
	public HasOrder KeycloakOtp { get; set; }

	[JsonPropertyName("keycloak-password")]
	public HasOrder KeycloakPassword { get; set; }
}