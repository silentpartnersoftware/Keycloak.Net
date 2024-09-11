namespace Keycloak.Net.Models.Root;

public class Authenticator
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public Dictionary<string, HasOrder> Providers { get; set; }
}