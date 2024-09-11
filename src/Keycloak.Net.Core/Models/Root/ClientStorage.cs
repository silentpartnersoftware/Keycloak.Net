namespace Keycloak.Net.Models.Root;

public class ClientStorage
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public MetadataClass Providers { get; set; }
}