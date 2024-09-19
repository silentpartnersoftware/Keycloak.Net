namespace Keycloak.Net.Models.Clients;

public class AddressClaimSet
{
	[JsonPropertyName("country")]
	public string Country { get; set; }
	[JsonPropertyName("formatted")]
	public string Formatted { get; set; }
	[JsonPropertyName("locality")]
	public string Locality { get; set; }
	[JsonPropertyName("postal_code")]
	public string PostalCode { get; set; }
	[JsonPropertyName("region")]
	public string Region { get; set; }
	[JsonPropertyName("street_address")]
	public string StreetAddress { get; set; }
}