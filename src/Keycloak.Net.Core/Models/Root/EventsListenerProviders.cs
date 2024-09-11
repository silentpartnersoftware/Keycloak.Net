namespace Keycloak.Net.Models.Root;

public class EventsListenerProviders
{
	[JsonPropertyName("jboss-logging")]
	public HasOrder JbossLogging { get; set; }

	[JsonPropertyName("email")]
	public HasOrder Email { get; set; }
}