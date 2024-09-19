namespace Keycloak.Net.Models.Common;

public class GlobalRequestResult
{
	[JsonPropertyName("failedRequests")]
	public IEnumerable<string> FailedRequests { get; set; }
	[JsonPropertyName("successRequests")]
	public IEnumerable<string> SuccessRequests { get; set; }
}