namespace Keycloak.Net.Models.Root;

public class TruststoreProviders
{
	[JsonPropertyName("file")]
	public HasOrder File { get; set; }
}