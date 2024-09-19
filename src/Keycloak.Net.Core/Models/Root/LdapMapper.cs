namespace Keycloak.Net.Models.Root;

public class LdapMapper
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public LdapMapperProviders Providers { get; set; }
}