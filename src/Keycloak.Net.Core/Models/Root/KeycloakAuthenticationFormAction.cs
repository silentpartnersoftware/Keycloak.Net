using Keycloak.Net.Models.Common;

namespace Keycloak.Net.Models.Root;

public class KeycloakAuthenticationFormAction
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("helpText")]
	public string HelpText { get; set; }

	[JsonPropertyName("properties")]
	public List<ConfigProperty> Properties { get; set; }

	[JsonPropertyName("metadata")]
	public MetadataClass Metadata { get; set; }
}