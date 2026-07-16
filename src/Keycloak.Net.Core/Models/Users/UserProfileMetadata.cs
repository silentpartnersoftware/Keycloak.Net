namespace Keycloak.Net.Models.Users;

public class UserProfileMetadata
{
	[JsonPropertyName("attributes")]
	public IEnumerable<UserProfileAttributeMetadata>? Attributes { get; set; }

	[JsonPropertyName("groups")]
	public IEnumerable<UserProfileAttributeGroupMetadata>? Groups { get; set; }
}
