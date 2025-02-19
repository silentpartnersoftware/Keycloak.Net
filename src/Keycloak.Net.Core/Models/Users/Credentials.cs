﻿namespace Keycloak.Net.Models.Users;

public class Credentials
{
	[JsonPropertyName("id")]
	public string Id { get; set; }
	[JsonPropertyName("algorithm")]
	public string Algorithm { get; set; }
	[JsonPropertyName("config")]
	public IDictionary<string, string> Config { get; set; }
	[JsonPropertyName("counter")]
	public int? Counter { get; set; }
	[JsonPropertyName("createdDate")]
	public long? CreatedDate { get; set; }
	[JsonPropertyName("device")]
	public string Device { get; set; }
	[JsonPropertyName("digits")]
	public int? Digits { get; set; }
	[JsonPropertyName("hashIterations")]
	public int? HashIterations { get; set; }
	[JsonPropertyName("hashedSaltedValue")]
	public string HashedSaltedValue { get; set; }
	[JsonPropertyName("period")]
	public int? Period { get; set; }
	[JsonPropertyName("salt")]
	public string Salt { get; set; }
	[JsonPropertyName("temporary")]
	public bool? Temporary { get; set; }
	[JsonPropertyName("type")]
	public string Type { get; set; }
	[JsonPropertyName("value")]
	public string Value { get; set; }
}