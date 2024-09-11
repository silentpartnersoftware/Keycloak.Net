namespace Keycloak.Net.Models.Root;

public class ClientRegistrationProviders
{
	[JsonPropertyName("default")]
	public HasOrder Default { get; set; }

	[JsonPropertyName("install")]
	public HasOrder Install { get; set; }

	[JsonPropertyName("saml2-entity-descriptor")]
	public HasOrder Saml2EntityDescriptor { get; set; }

	[JsonPropertyName("openid-connect")]
	public HasOrder OpenIdConnect { get; set; }
}