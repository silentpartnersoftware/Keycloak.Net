namespace Keycloak.Net.Models.Root;

public class ClientDescriptionConverterProviders
{
	[JsonPropertyName("keycloak")]
	public HasOrder Keycloak { get; set; }

	[JsonPropertyName("saml2-entity-descriptor")]
	public HasOrder Saml2EntityDescriptor { get; set; }

	[JsonPropertyName("openid-connect")]
	public HasOrder OpenIdConnect { get; set; }
}