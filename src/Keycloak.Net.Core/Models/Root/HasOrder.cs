namespace Keycloak.Net.Models.Root;

public class HasOrder
{
	[JsonPropertyName("order")]
	public long Order { get; set; }
}