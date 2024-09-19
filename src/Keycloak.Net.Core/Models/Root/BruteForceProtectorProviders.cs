namespace Keycloak.Net.Models.Root;

public class BruteForceProtectorProviders
{
	[JsonPropertyName("default-brute-force-detector")]
	public HasOrder DefaultBruteForceDetector { get; set; }
}