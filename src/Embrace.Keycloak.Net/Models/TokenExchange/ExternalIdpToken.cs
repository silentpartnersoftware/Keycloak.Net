using Newtonsoft.Json;

namespace Keycloak.Net.Models.TokenExchange;

public class ExternalIdpToken
{
    [JsonProperty("token_type")]
    public string TokenType { get; init; }

    [JsonProperty("access_token")]
    public string AccessToken { get; init; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; init; }

    [JsonProperty("issued_token_type")]
    public string IssuedTokenType { get; init; }

    [JsonProperty("scope")]
    public string Scope { get; init; }

    [JsonProperty("refresh_expires_in")]
    public int RefreshTokenExpiresIn { get; init; }

    [JsonProperty("not-before-policy")]
    public long NotBeforePolicy { get; init; }

    [JsonProperty("account-link-url")]
    public string AccountLinkUrl { get; init; }
}
