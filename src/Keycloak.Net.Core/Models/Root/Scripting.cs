namespace Keycloak.Net.Models.Root;

public class Scripting
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public ScriptingProviders Providers { get; set; }
}