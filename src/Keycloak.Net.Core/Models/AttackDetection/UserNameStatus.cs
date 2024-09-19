namespace Keycloak.Net.Models.AttackDetection;

public class UserNameStatus
{
	[JsonPropertyName("numFailures")]
	public int? NumFailures { get; set; }
	[JsonPropertyName("disabled")]
	public bool? Disabled { get; set; }
	[JsonPropertyName("lastIPFailure")]
	public string LastIpFailure { get; set; }
	[JsonPropertyName("lastFailure")]
	public int? LastFailure { get; set; }
}