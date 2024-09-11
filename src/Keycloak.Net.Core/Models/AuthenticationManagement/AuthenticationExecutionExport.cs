namespace Keycloak.Net.Models.AuthenticationManagement;

public class AuthenticationExecutionExport : AuthenticationExecutionBase
{
	[JsonPropertyName("flowAlias")]
	public string FlowAlias { get; set; }
	[JsonPropertyName("userSetupAllowed")]
	public bool? UserSetupAllowed { get; set; }
}