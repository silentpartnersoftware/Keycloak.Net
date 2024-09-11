namespace Keycloak.Net.Models.Root;

public class Hostname
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public HostnameProviders Providers { get; set; }
}