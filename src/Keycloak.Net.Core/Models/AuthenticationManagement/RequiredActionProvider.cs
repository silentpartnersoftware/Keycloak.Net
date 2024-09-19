namespace Keycloak.Net.Models.AuthenticationManagement;

public class RequiredActionProvider
{
	[JsonPropertyName("alias")]
	public string Alias { get; set; }
	[JsonPropertyName("config")]
	public IDictionary<string, object> Config { get; set; }
	[JsonPropertyName("defaultAction")]
	public bool? DefaultAction { get; set; }
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
	[JsonPropertyName("name")]
	public string Name { get; set; }
	[JsonPropertyName("priority")]
	public int? Priority { get; set; }
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; }
}