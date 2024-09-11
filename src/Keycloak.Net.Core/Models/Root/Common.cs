using Keycloak.Net.Common.Converters;

namespace Keycloak.Net.Models.Root;

public class Common
{
	[JsonPropertyName("name")]
	[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Name>))]
	public Name Name { get; set; }
}