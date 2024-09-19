namespace Keycloak.Net.Models.Root;

public class ClientDescriptionConverter
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ClientDescriptionConverterProviders Providers { get; set; }
}