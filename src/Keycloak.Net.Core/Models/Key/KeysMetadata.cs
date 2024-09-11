namespace Keycloak.Net.Models.Key;

public class KeysMetadata
{
	[JsonPropertyName("active")]
	public Active Active { get; set; }
	[JsonPropertyName("keys")]
	public IEnumerable<Key> Keys { get; set; }
}