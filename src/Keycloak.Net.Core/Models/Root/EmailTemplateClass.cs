namespace Keycloak.Net.Models.Root;

public class EmailTemplateClass
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public AccountProviders Providers { get; set; }
}