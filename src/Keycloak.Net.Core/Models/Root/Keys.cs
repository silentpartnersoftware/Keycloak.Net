namespace Keycloak.Net.Models.Root;

public class Keys
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public KeysProviders Providers { get; set; }
}