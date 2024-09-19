namespace Keycloak.Net.Models.Root;

public class Oauth2TokenIntrospection
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public Oauth2TokenIntrospectionProviders Providers { get; set; }
}