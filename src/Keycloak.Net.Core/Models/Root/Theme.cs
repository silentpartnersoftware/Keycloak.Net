namespace Keycloak.Net.Models.Root;

public class Theme
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ThemeProviders Providers { get; set; }
}