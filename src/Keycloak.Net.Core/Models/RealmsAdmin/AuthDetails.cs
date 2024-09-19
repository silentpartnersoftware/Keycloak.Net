namespace Keycloak.Net.Models.RealmsAdmin;

public class AuthDetails
{
	[JsonPropertyName("clientId")]
	public string ClientId { get; set; }
	[JsonPropertyName("ipAddress")]
	public string IpAddress { get; set; }
	[JsonPropertyName("realmId")]
	public string RealmId { get; set; }
	[JsonPropertyName("userId")]
	public string UserId { get; set; }
}