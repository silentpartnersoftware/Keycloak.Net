namespace Keycloak.Net.Models.Root;

public class BuiltinProtocolMappers
{
	[JsonPropertyName("saml")]
	public List<Saml> Saml { get; set; }

	[JsonPropertyName("openid-connect")]
	public List<OpenIdConnect> OpenIdConnect { get; set; }
}