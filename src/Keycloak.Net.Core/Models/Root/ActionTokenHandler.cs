namespace Keycloak.Net.Models.Root;

public class ActionTokenHandler
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ActionTokenHandlerProviders Providers { get; set; }
}