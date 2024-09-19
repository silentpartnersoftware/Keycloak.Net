using System;
using System.Text.Json;
using Flurl;
using Flurl.Http.Configuration;
using Keycloak.Net.Common.Extensions;

namespace Keycloak.Net;

public partial class KeycloakClient
{
	private ISerializer _serializer = new DefaultJsonSerializer(new()
																{
																	PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
																	DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
																});

	private readonly Url _url;
	private readonly string _userName;
	private readonly string _password;
	private readonly string _clientSecret;
	private readonly Func<string> _getToken;
	private readonly KeycloakOptions _options;

	private KeycloakClient(string url, KeycloakOptions options)
	{
		_url = url;
		_options = options ?? new KeycloakOptions();
	}

	public KeycloakClient(string url,
						  string userName,
						  string password,
						  KeycloakOptions? options = null) : this(url, options)
	{
		_userName = userName;
		_password = password;
	}

	public KeycloakClient(string url,
						  string clientSecret,
						  KeycloakOptions? options = null) : this(url, options)
	{
		_clientSecret = clientSecret;
	}

	public KeycloakClient(string url,
						  Func<string> getToken,
						  KeycloakOptions? options = null) : this(url, options)
	{
		_getToken = getToken;
	}

	public void SetSerializer(ISerializer serializer) =>
		_serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));

	private IFlurlRequest GetBaseUrl(string authenticationRealm) =>
		new Url(_url).AppendPathSegment(_options.Prefix)
					 .WithSettings(settings => settings.JsonSerializer = _serializer)
					 .WithAuthentication(_getToken,
										 _url,
										 _options.AuthenticationRealm ?? authenticationRealm,
										 _userName,
										 _password,
										 _clientSecret,
										 _options);

	internal record CountDto(int Count);
}

public class KeycloakOptions
{
	public string Prefix { get; }
	public string AdminClientId { get; }

	/// <summary>
	/// It is used only when the authorization realm differs from the target one
	/// </summary>
	public string AuthenticationRealm { get; }
        
	public KeycloakOptions(string prefix = "",
						   string adminClientId = "admin-cli",
						   string? authenticationRealm = default)
	{
		Prefix = prefix.TrimStart('/').TrimEnd('/');
		AdminClientId = adminClientId;
		AuthenticationRealm = authenticationRealm;
	}
}