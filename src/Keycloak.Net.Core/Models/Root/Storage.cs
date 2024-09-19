namespace Keycloak.Net.Models.Root;

public class Storage
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public StorageProviders Providers { get; set; }
}