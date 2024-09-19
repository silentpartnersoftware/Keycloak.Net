using Keycloak.Net.Common.Converters;
using System.Runtime.Serialization;

namespace Keycloak.Net.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Locale>))]
public enum Locale
{
	En,
	Ar,
	Ca,
	Cs,
	Da,
	De,
	El,
	Es,
	Fa,
	Fr,
	Fi,
	Hu,
	It,
	Ja,
	Lt,
	Lv,
	Nl,
	No,
	Pl,
	Pt,
	[EnumMember(Value = "pt-BR")]
	PtBr,
	Ru,
	Sk,
	Sv,
	Th,
	Tr,
	Uk,
	[EnumMember(Value = "zh-CN")]
	ZhCn,
	[EnumMember(Value = "zh-TW")]
	ZhTw
}