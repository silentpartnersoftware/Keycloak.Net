using Keycloak.Net.Common.Converters;
using System.Runtime.Serialization;

namespace Keycloak.Net.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<GroupName>))]
public enum GroupName
{
	Social,
	[EnumMember(Value = "User-defined")]
	UserDefined
}