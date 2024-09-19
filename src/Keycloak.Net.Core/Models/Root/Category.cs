using System.Runtime.Serialization;
using Keycloak.Net.Common.Converters;

namespace Keycloak.Net.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Category>))]
public enum Category
{
	[EnumMember(Value = "AttributeStatement Mapper")]
	AttributeStatementMapper,
	[EnumMember(Value = "Docker Auth Mapper")]
	DockerAuthMapper,
	[EnumMember(Value = "Group Mapper")]
	GroupMapper,
	[EnumMember(Value = "Role Mapper")]
	RoleMapper,
	[EnumMember(Value = "Token mapper")]
	TokenMapper,
	[EnumMember(Value = "NameID Mapper")]
	NameIdMapper,
	[EnumMember(Value = "Audience mapper")]
	AudienceMapper,
}