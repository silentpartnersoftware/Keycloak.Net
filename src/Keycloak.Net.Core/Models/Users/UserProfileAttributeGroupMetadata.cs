namespace Keycloak.Net.Models.Users;

public class UserProfileAttributeGroupMetadata
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("displayHeader")]
	public string? DisplayHeader { get; set; }

	[JsonPropertyName("displayDescription")]
	public string? DisplayDescription { get; set; }

	[JsonPropertyName("annotations")]
	public IDictionary<string, object>? Annotations { get; set; }
}
