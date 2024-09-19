namespace Keycloak.Net.Models.ProtocolMappers;

public class ProtocolMapper
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("protocol")]
	public string Protocol { get; set; }
	[JsonPropertyName("protocolMapper")]
	// ReSharper disable once InconsistentNaming
	public string _ProtocolMapper { get; set; }
	[JsonPropertyName("consentRequired")]
	public bool? ConsentRequired { get; set; }
	[JsonPropertyName("config")]
	public Dictionary<string, string> Config { get; set; }
}