using System.Runtime.Serialization;

namespace Keycloak.Net.Models.Root;

public enum Name
{
	Base,
	Keycloak,
	[EnumMember(Value = "keycloak.v2")]
	KeycloakV2,
	[EnumMember(Value = "keycloak.v3")]
	KeycloakV3,
	RhSso
}