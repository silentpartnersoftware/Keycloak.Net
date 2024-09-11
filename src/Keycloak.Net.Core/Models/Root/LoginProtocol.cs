namespace Keycloak.Net.Models.Root;

public class LoginProtocol
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public LoginProtocolProviders Providers { get; set; }
}