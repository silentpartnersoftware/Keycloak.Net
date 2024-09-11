using Keycloak.Net.Common.Converters;

namespace Keycloak.Net.Models.AuthorizationPermissions;

public class AuthorizationPermission
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public AuthorizationPermissionType Type { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyDecisionLogic Logic { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("resourceType")]
	public string ResourceType { get; set; }

	[JsonPropertyName("resources")]
	public IEnumerable<string> ResourceIds { get; set; }

	[JsonPropertyName("scopes")]
	public IEnumerable<string> ScopeIds { get; set; }

	[JsonPropertyName("policies")]
	public IEnumerable<string> PolicyIds { get; set; }
}

public enum PolicyDecisionLogic
{
	Positive,
	Negative
}

public enum AuthorizationPermissionType
{
	Scope,
	Resource
}

public enum DecisionStrategy
{
	Unanimous,
	Affirmative,
	Consensus
}