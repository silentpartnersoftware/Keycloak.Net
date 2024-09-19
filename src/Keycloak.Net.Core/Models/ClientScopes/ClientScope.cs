using Keycloak.Net.Models.ProtocolMappers;

namespace Keycloak.Net.Models.ClientScopes;

public class ClientScope
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("description")]
	public string Description { get; set; }
	[JsonPropertyName("protocol")]
	public string Protocol { get; set; }
	[JsonPropertyName("attributes")]
	public Attributes Attributes { get; set; }
	[JsonPropertyName("protocolMappers")]
	public IEnumerable<ProtocolMapper> ProtocolMappers { get; set; }
}