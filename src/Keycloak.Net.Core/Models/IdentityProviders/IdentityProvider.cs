namespace Keycloak.Net.Models.IdentityProviders;

public class IdentityProvider
{
	[JsonPropertyName("alias")]
	public string Alias { get; set; }
	[JsonPropertyName("displayName")]
	public string? DisplayName { get; set; }
	[JsonPropertyName("internalId")]
	public string InternalId { get; set; }
	[JsonPropertyName("providerId")]
	public string ProviderId { get; set; }
	[JsonPropertyName("enabled")]
	public bool? Enabled { get; set; }
	[JsonPropertyName("updateProfileFirstLoginMode")]
	public string UpdateProfileFirstLoginMode { get; set; }
	[JsonPropertyName("trustEmail")]
	public bool? TrustEmail { get; set; }
	[JsonPropertyName("storeToken")]
	public bool? StoreToken { get; set; }
	[JsonPropertyName("addReadTokenRoleOnCreate")]
	public bool? AddReadTokenRoleOnCreate { get; set; }
	[JsonPropertyName("authenticateByDefault")]
	public bool? AuthenticateByDefault { get; set; }
	[JsonPropertyName("linkOnly")]
	public bool? LinkOnly { get; set; }
	[JsonPropertyName("hideOnLogin")]
	public bool? HideOnLogin { get; set; }
	[JsonPropertyName("firstBrokerLoginFlowAlias")]
	public string FirstBrokerLoginFlowAlias { get; set; }
	[JsonPropertyName("postBrokerLoginFlowAlias")]
	public string? PostBrokerLoginFlowAlias { get; set; }
	[JsonPropertyName("organizationId")]
	public string? OrganizationId { get; set; }
	[JsonPropertyName("config")]
	public Config Config { get; set; }
	[JsonPropertyName("types")]
	public IEnumerable<string>? Types { get; set; }
	[JsonPropertyName("updateProfileFirstLogin")]
	public bool? UpdateProfileFirstLogin { get; set; }
}
