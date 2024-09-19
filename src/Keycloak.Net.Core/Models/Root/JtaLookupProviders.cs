namespace Keycloak.Net.Models.Root;

public class JtaLookupProviders
{
	[JsonPropertyName("jboss")]
	public HasOrder Jboss { get; set; }
}