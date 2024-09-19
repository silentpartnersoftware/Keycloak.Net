namespace Keycloak.Net.Models.ClientScopes;

public class Attributes
{
	[JsonPropertyName("consent.screen.text")]
	public string ConsentScreenText { get; set; }
	[JsonPropertyName("display.on.consent.screen")]
	public string DisplayOnConsentScreen { get; set; }
	[JsonPropertyName("include.in.token.scope")]
	public string IncludeInTokenScope { get; set; }
	[JsonPropertyName("gui.order")]
	public string DisplayOrder { get; set; }
}