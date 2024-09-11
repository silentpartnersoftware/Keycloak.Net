namespace Keycloak.Net.Models.Root;

public class FormAction
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public FormActionProviders Providers { get; set; }
}