namespace Keycloak.Net.Models.Root;

public class Default
{
	[JsonPropertyName("order")]
	public long Order { get; set; }

	[JsonPropertyName("operationalInfo")]
	public OperationalInfo OperationalInfo { get; set; }
}