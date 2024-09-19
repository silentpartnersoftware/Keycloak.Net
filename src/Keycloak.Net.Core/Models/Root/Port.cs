namespace Keycloak.Net.Models.Root;

public class Port
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ExportProviders Providers { get; set; }
}