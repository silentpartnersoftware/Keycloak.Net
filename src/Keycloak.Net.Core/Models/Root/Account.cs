using Keycloak.Net.Common.Converters;

namespace Keycloak.Net.Models.Root;

public class Account
{
	[JsonPropertyName("name")]
	[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Name>))]
	public Name Name { get; set; }

	[JsonPropertyName("locales")]
	public List<Locale> Locales { get; set; }
}