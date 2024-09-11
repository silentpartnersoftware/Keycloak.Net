using Keycloak.Net.Common.Converters;
using System.Runtime.Serialization;

namespace Keycloak.Net.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Protocol>))]
public enum Protocol
{
	[EnumMember(Value = "docker-v2")]
	DockerV2,
	[EnumMember(Value = "openid-connect")]
	OpenIdConnect,
	Saml
}