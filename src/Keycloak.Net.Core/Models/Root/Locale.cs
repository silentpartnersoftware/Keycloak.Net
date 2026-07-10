using Keycloak.Net.Common.Converters;
using System.Runtime.Serialization;

namespace Keycloak.Net.Models.Root;

[JsonConverter(typeof(EnumMemberJsonStringEnumConverter<Locale>))]
public enum Locale
{
	En,
	Ar,
	Az,
	Ca,
	Cs,
	Da,
	De,
	El,
	Es,
	Eu,
	Fa,
	Fr,
	Fi,
	Hr,
	Hu,
	Hy,
	Id,
	It,
	Ja,
	Kk,
	Ko,
	Ky,
	Lt,
	Lv,
	Nl,
	No,
	Pl,
	Pt,
	[EnumMember(Value = "pt-BR")]
	PtBr,
	Ro,
	Ru,
	Sk,
	Sl,
	Sv,
	Th,
	Tr,
	Uk,
	Vi,
	[EnumMember(Value = "zh-CN")]
	ZhCn,
	[EnumMember(Value = "zh-TW")]
	ZhTw
}
