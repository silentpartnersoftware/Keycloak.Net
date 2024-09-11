namespace Keycloak.Net.Models.Root;

public class ScriptingProviders
{
	[JsonPropertyName("script-based-auth")]
	public HasOrder ScriptBasedAuth { get; set; }
}