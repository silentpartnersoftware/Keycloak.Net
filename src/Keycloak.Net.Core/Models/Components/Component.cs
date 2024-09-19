namespace Keycloak.Net.Models.Components;

public class Component
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; }
	[JsonPropertyName("providerType")]
	public string ProviderType { get; set; }
	[JsonPropertyName("parentId")]
	public string ParentId { get; set; }
	[JsonPropertyName("config")]
	public Config Config { get; set; }
	[JsonPropertyName("subType")]
	public string SubType { get; set; }
}