using Keycloak.Net.Models.AuthorizationPermissions;

namespace Keycloak.Net.Models.Clients;

public class Policy
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; }

	public PolicyDecisionLogic Logic { get; set; }

	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("config")]
	public PolicyConfig Config { get; set; }
}

public class RolePolicy
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; } = PolicyType.Role;

	public PolicyDecisionLogic Logic { get; set; }

	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("roles")]
	public IEnumerable<RoleConfig> RoleConfigs { get; set; }
}

public class RoleConfig
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("required")]
	public bool Required { get; set; }
}

public class UserPolicy
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; } = PolicyType.User;

	public PolicyDecisionLogic Logic { get; set; }

	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("users")]
	public IEnumerable<string> Users { get; set; }
}

public class GroupPolicy
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("description")]
	public string Description { get; set; }

	[JsonConverter(typeof(JsonStringEnumConverter))]
	public PolicyType Type { get; set; } = PolicyType.Group;

	public PolicyDecisionLogic Logic { get; set; }

	public DecisionStrategy DecisionStrategy { get; set; }

	[JsonPropertyName("groups")]
	public IEnumerable<GroupConfig> GroupConfigs { get; set; }

	[JsonPropertyName("groupsClaim")]
	public string GroupsClaim { get; set; }
}

public class GroupConfig
{
	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("path")]
	public string Path { get; set; }

	[JsonPropertyName("extendChildren")]
	public bool ExtendChildren { get; set; }
}

public enum PolicyType
{
	Role,
	Client,
	Time,
	User,
	Aggregate,
	Group,
	Js
}

public class PolicyConfig
{
	[JsonPropertyName("roles")]
	public IEnumerable<RoleConfig> RoleConfigs { get; set; }
}