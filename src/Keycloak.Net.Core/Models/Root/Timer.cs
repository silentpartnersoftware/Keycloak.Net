namespace Keycloak.Net.Models.Root;

public class Timer
{
	[JsonPropertyName("internal")]
	public bool? Internal { get; set; }

	[JsonPropertyName("providers")]
	public TimerProviders Providers { get; set; }
}