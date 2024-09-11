namespace Keycloak.Net.Models.Root;

public class JtaLookup
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public JtaLookupProviders Providers { get; set; }
}