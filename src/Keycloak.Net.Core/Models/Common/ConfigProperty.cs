using Keycloak.Net.Models.Root;

namespace Keycloak.Net.Models.Common;

public class ConfigProperty
{
	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("label")]
	public string Label { get; set; }

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; }

	[JsonPropertyName("type")]
	public JsonTypeLabel Type { get; set; }

	[JsonPropertyName("secret")]
	public bool? Secret { get; set; }

	[JsonPropertyName("defaultValue")]
	public object DefaultValue { get; set; }

	[JsonPropertyName("options")]
	public List<string> Options { get; set; }
}