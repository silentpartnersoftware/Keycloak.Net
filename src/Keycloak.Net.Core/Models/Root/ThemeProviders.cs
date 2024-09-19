namespace Keycloak.Net.Models.Root;

public class ThemeProviders
{
	[JsonPropertyName("folder")]
	public HasOrder Folder { get; set; }

	[JsonPropertyName("module")]
	public HasOrder Module { get; set; }

	[JsonPropertyName("jar")]
	public HasOrder Jar { get; set; }

	[JsonPropertyName("extending")]
	public HasOrder Extending { get; set; }
}