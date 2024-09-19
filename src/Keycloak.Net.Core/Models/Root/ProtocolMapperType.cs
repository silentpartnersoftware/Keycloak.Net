using Keycloak.Net.Models.Common;

namespace Keycloak.Net.Models.Root;

public class ProtocolMapperType
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("category")]
	public Category Category { get; set; }

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; }

	[JsonPropertyName("priority")]
	public long Priority { get; set; }

	[JsonPropertyName("properties")]
	public List<ConfigProperty> Properties { get; set; }
}