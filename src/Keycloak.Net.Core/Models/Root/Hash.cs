namespace Keycloak.Net.Models.Root;

public class Hash
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public HashProviders Providers { get; set; }
}