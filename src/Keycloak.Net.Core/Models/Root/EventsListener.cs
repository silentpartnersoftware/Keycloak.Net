namespace Keycloak.Net.Models.Root;

public class EventsListener
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public EventsListenerProviders Providers { get; set; }
}