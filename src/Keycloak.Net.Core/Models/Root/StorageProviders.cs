namespace Keycloak.Net.Models.Root;

public class StorageProviders
{
	[JsonPropertyName("ldap")]
	public HasOrder Ldap { get; set; }

	[JsonPropertyName("kerberos")]
	public HasOrder Kerberos { get; set; }
}