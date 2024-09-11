namespace Keycloak.Net.Models.Root;

public class ActionTokenProviders
{
	[JsonPropertyName("infinispan")]
	public HasOrder Infinispan { get; set; }
}