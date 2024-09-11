namespace Keycloak.Net.Models.Root;

public class ClientInstallations
{
	[JsonPropertyName("docker-v2")]
	public List<ClientInstallation> DockerV2 { get; set; }

	[JsonPropertyName("saml")]
	public List<ClientInstallation> Saml { get; set; }

	[JsonPropertyName("openid-connect")]
	public List<ClientInstallation> OpenIdConnect { get; set; }
}