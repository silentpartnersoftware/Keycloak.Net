namespace Keycloak.Net.Models.Root;

public class LoginProtocolProviders
{
	[JsonPropertyName("saml")]
	public HasOrder Saml { get; set; }

	[JsonPropertyName("openid-connect")]
	public HasOrder OpenIdConnect { get; set; }
}