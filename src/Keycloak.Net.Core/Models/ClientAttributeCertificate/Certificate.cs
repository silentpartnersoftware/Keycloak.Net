namespace Keycloak.Net.Models.ClientAttributeCertificate;

public class Certificate
{
	[JsonPropertyName("certificate")]
	// ReSharper disable once InconsistentNaming
	public string _Certificate { get; set; }
	[JsonPropertyName("kid")]
	public string Kid { get; set; }
	[JsonPropertyName("privateKey")]
	public string PrivateKey { get; set; }
	[JsonPropertyName("publicKey")]
	public string PublicKey { get; set; }
}