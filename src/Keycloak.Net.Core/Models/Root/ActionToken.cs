namespace Keycloak.Net.Models.Root;

public class ActionToken
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ActionTokenProviders Providers { get; set; }
}