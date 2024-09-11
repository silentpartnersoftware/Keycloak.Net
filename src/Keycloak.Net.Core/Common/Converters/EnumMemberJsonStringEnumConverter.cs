using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Keycloak.Net.Common.Converters;

/// <summary>
/// Provides an AOT-compatible extension for <see cref="JsonStringEnumConverter"/> that adds support for <see cref="EnumMemberAttribute"/>.
/// </summary>
/// <typeparam name="TEnum">The type of the <see cref="TEnum"/>.</typeparam>
public sealed class EnumMemberJsonStringEnumConverter<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicFields)] TEnum>()
	: JsonStringEnumConverter<TEnum>(namingPolicy: ResolveNamingPolicy())
	where TEnum : struct, Enum
{
	private static EnumMemberNamingPolicy? ResolveNamingPolicy()
	{
		var map = typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static)
							   .Select(f => (f.Name, AttributeName: f.GetCustomAttribute<EnumMemberAttribute>()?.Value))
							   .Where(pair => pair.AttributeName != null)
							   .ToDictionary();

		return map.Count > 0
				   ? new EnumMemberNamingPolicy(map!)
				   : null;
	}

	private sealed class EnumMemberNamingPolicy(Dictionary<string, string> map) : JsonNamingPolicy
	{
		public override string ConvertName(string name)
			=> map.GetValueOrDefault(name, name);
	}
}