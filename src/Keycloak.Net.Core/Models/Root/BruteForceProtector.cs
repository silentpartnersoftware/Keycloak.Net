namespace Keycloak.Net.Models.Root;

public class BruteForceProtector
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public BruteForceProtectorProviders Providers { get; set; }
}