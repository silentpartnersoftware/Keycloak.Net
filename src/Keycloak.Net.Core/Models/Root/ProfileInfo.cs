namespace Keycloak.Net.Models.Root;

public class ProfileInfo
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("disabledFeatures")]
	public List<string> DisabledFeatures { get; set; }

	[JsonPropertyName("previewFeatures")]
	public List<string> PreviewFeatures { get; set; }

	[JsonPropertyName("experimentalFeatures")]
	public List<string> ExperimentalFeatures { get; set; }
}