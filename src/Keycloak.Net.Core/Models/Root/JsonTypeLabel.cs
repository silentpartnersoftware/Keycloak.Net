using Keycloak.Net.Common.Converters;

namespace Keycloak.Net.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<JsonTypeLabel>))]
public enum JsonTypeLabel
{
	Boolean,
	ClientList,
	File,
	List,
	MultivaluedList,
	MultivaluedString,
	Password,
	Role,
	Script,
	String,
	Text,
	Long,
	UserProfileAttributeList,
	Map,
	Group
}