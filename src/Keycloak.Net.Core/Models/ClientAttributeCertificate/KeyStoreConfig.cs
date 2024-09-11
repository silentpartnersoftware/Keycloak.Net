namespace Keycloak.Net.Models.ClientAttributeCertificate;

public class KeyStoreConfig
{
	[JsonPropertyName("format")]
	public string Format { get; set; }
	[JsonPropertyName("keyAlias")]
	public string KeyAlias { get; set; }
	[JsonPropertyName("keyPassword")]
	public string KeyPassword { get; set; }
	[JsonPropertyName("realmAlias")]
	public string RealmAlias { get; set; }
	[JsonPropertyName("realmCertificate")]
	public string RealmCertificate { get; set; }
	[JsonPropertyName("storePassword")]
	public string StorePassword { get; set; }
}