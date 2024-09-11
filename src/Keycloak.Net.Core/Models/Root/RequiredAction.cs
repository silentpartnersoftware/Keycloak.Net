namespace Keycloak.Net.Models.Root;

public class RequiredAction
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public RequiredActionProviders Providers { get; set; }
}