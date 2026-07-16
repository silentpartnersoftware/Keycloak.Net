using Flurl;
using System;

namespace Keycloak.Net.Common.Extensions;

public static class FlurlRequestExtensions
{
    private static string GetCacheKey(string url, string realm, string userName, string adminClientId)
    {
        return $"password¦{url}¦{realm}¦{userName}¦{adminClientId}";
    }

    private static string GetCacheKey(string url, string realm, string adminClientId)
    {
        return $"client_credentials¦{url}¦{realm}¦{adminClientId}";
    }

    private static async Task<string> GetAccessTokenAsync(string url,
														  string realm,
														  string userName,
														  string password,
														  KeycloakOptions? options = null)
	{
		options ??= new();

        var cacheKey = GetCacheKey(url, realm, userName, options.AdminClientId);
        var canCache = options.AccessTokenCache != null;

        if (canCache)
        {
            var cachedAccessToken = await options.AccessTokenCache!.GetFromCacheAsync(cacheKey, CancellationToken.None);

            if (!string.IsNullOrEmpty(cachedAccessToken))
            {
                return cachedAccessToken;
            }
        }

		var request = url.AppendPathSegment($"{options.Prefix}/realms/{realm}/protocol/openid-connect/token")
						 .WithHeader("Accept", "application/json");

		if (options.Timeout.HasValue)
		{
			request = request.WithTimeout(options.Timeout.Value);
		}

		var result = await request.PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
													   {
														   new("grant_type", "password"),
														   new("username", userName),
														   new("password", password),
														   new("client_id", options.AdminClientId)
													   })
								  .ReceiveJson<AccessTokenDto>()
								  .ConfigureAwait(false);

        if (canCache)
        {
            await options.AccessTokenCache!.AddToCacheAsync(cacheKey, result.AccessToken, CancellationToken.None);
        }

		return result.AccessToken;
	}

	private static string GetAccessToken(string url,
										 string realm,
										 string userName,
										 string password,
										 KeycloakOptions? options = null) =>
		GetAccessTokenAsync(url,
							realm,
							userName,
							password,
							options).GetAwaiter()
									.GetResult();

	private static async Task<string> GetAccessTokenAsync(string url,
														  string realm,
														  string clientSecret,
														  KeycloakOptions? options = null)
	{
		options ??= new();

        var cacheKey = GetCacheKey(url, realm, options.AdminClientId);
        var canCache = options.AccessTokenCache != null;

        if (canCache)
        {
            var cachedAccessToken = await options.AccessTokenCache!.GetFromCacheAsync(cacheKey, CancellationToken.None);

            if (!string.IsNullOrEmpty(cachedAccessToken))
            {
                return cachedAccessToken;
            }
        }

        var request = url.AppendPathSegment($"{options.Prefix}/realms/{realm}/protocol/openid-connect/token")
						 .WithHeader("Content-Type", "application/x-www-form-urlencoded");

		if (options.Timeout.HasValue)
		{
			request = request.WithTimeout(options.Timeout.Value);
		}

        var result = await request.PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
													   {
														   new("grant_type", "client_credentials"),
														   new("client_secret", clientSecret),
														   new("client_id", options.AdminClientId)
													   })
								  .ReceiveJson<AccessTokenDto>()
								  .ConfigureAwait(false);

        if (canCache)
        {
            await options.AccessTokenCache!.AddToCacheAsync(cacheKey, result.AccessToken, CancellationToken.None);
        }

        return result.AccessToken;
	}

	private static string GetAccessToken(string url,
										 string realm,
										 string clientSecret,
										 KeycloakOptions? options = null) =>
		GetAccessTokenAsync(url,
							realm,
							clientSecret,
							options).GetAwaiter()
									.GetResult();

	public static IFlurlRequest WithAuthentication(this IFlurlRequest request,
												   Func<string>? getToken,
												   string url,
												   string realm,
												   string userName,
												   string password,
												   string? clientSecret,
												   KeycloakOptions? options = null)
	{
		var token = getToken is not null
						? getToken() 
						: clientSecret is not null 
							? GetAccessToken(url,
											 realm,
											 clientSecret,
											 options) 
							: GetAccessToken(url,
											 realm,
											 userName,
											 password,
											 options);

		return request.WithOAuthBearerToken(token);
	}

	public static IFlurlRequest WithForwardedHttpHeaders(this IFlurlRequest request,
														 ForwardedHttpHeaders forwardedHeaders)
	{
		if (!string.IsNullOrEmpty(forwardedHeaders?.forwardedFor))
			request = request.WithHeader("X-Forwarded-For", forwardedHeaders.forwardedFor);

		if (!string.IsNullOrEmpty(forwardedHeaders?.forwardedProto))
			request = request.WithHeader("X-Forwarded-Proto", forwardedHeaders.forwardedProto);

		if (!string.IsNullOrEmpty(forwardedHeaders?.forwardedHost))
			request = request.WithHeader("X-Forwarded-Host", forwardedHeaders.forwardedHost);

		return request;
	}

	internal record AccessTokenDto([property: JsonPropertyName("access_token")] string AccessToken);
}
