namespace Keycloak.Net.Models.Root;

public class WellKnown
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public WellKnownProviders Providers { get; set; }
}