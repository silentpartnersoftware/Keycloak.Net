namespace Keycloak.Net.Models.Root;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ConfigType
{
	Int,
	String
}