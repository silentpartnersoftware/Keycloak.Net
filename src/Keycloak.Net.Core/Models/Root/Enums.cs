namespace Keycloak.Net.Models.Root;

public class Enums
{
	[JsonPropertyName("operationType")]
	public List<string> OperationType { get; set; }

	[JsonPropertyName("eventType")]
	public List<string> EventType { get; set; }

	[JsonPropertyName("resourceType")]
	public List<string> ResourceType { get; set; }
}