using Keycloak.Net.Common.Converters;
using System.Runtime.Serialization;

namespace Keycloak.Net.Models.Organizations;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<MembershipType>))]
public enum MembershipType
{
	
	[EnumMember(Value = "MANAGED")]
	Managed,
	[EnumMember(Value = "UNMANAGED")]
	Unmanaged,
}