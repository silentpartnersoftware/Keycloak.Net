using Keycloak.Net.Models.Common;

namespace Keycloak.Net.Models.Components;

public class ComponentType
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("helpText")]
	public string HelpText { get; set; }
	[JsonPropertyName("properties")]
	public IEnumerable<ConfigProperty> Properties { get; set; }
	[JsonPropertyName("metadata")]
	public IDictionary<string, object> Metadata { get; set; }
}