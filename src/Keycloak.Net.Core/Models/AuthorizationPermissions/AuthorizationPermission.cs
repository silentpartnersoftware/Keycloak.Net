using System.Runtime.Serialization;
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

	public PolicyDecisionLogic Logic { get; set; }

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

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<PolicyDecisionLogic>))]
public enum PolicyDecisionLogic
{

	[EnumMember(Value = "POSITIVE")]
	Positive,

	[EnumMember(Value = "NEGATIVE")]
	Negative
}

public enum AuthorizationPermissionType
{
	Scope,
	Resource
}

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<DecisionStrategy>))]
public enum DecisionStrategy
{
	[EnumMember(Value = "UNANIMOUS")]
	Unanimous,

	[EnumMember(Value = "AFFIRMATIVE")]
	Affirmative,

	[EnumMember(Value = "CONSENSUS")]
	Consensus
}