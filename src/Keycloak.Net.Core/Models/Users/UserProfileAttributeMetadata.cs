namespace Keycloak.Net.Models.Users;

public class UserProfileAttributeMetadata
{
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("displayName")]
	public string? DisplayName { get; set; }

	[JsonPropertyName("required")]
	public bool? Required { get; set; }

	[JsonPropertyName("readOnly")]
	public bool? ReadOnly { get; set; }

	[JsonPropertyName("annotations")]
	public IDictionary<string, object>? Annotations { get; set; }

	[JsonPropertyName("validators")]
	public IDictionary<string, IDictionary<string, object>>? Validators { get; set; }

	[JsonPropertyName("group")]
	public string? Group { get; set; }

	[JsonPropertyName("multivalued")]
	public bool? Multivalued { get; set; }

	[JsonPropertyName("defaultValue")]
	public string? DefaultValue { get; set; }
}
