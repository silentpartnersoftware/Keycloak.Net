using System.Runtime.Serialization;
using Keycloak.Net.Common.Converters;

namespace Keycloak.Net.Models.RealmsAdmin;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Policies>))]
public enum Policies
{
	[EnumMember(Value = "SKIP")]
	Skip,
	[EnumMember(Value = "OVERWRITE")]
	Overwrite,
	[EnumMember(Value = "FAIL")]
	Fail
}