namespace Keycloak.Net.Models.Common;

public class ManagementPermission
{
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
}