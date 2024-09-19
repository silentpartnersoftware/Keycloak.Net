namespace Keycloak.Net.Models.Root;

public class AuthorizationPersisterProviders
{
	[JsonPropertyName("jpa")]
	public HasOrder Jpa { get; set; }
}