namespace Keycloak.Net.Models.Root;

public class Policy
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public PolicyProviders Providers { get; set; }
}