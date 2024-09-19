namespace Keycloak.Net.Models.Root;

public class FormAuthenticatorProviders
{
	[JsonPropertyName("registration-page-form")]
	public HasOrder RegistrationPageForm { get; set; }
}