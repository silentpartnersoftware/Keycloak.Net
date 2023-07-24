namespace Keycloak.Net;

public static class Constants
{
    public static class HttpConstants
    {
        public const string ContentType = "Content-Type";
        public const string FormUrlEncoded = "application/x-www-form-urlencoded";
    }
    
    public static class AuthKeywords
    {
        public const string ClientId = "client_id";
        public const string ClientSecret = "client_secret";
        public const string Username = "username";
        public const string Password = "password";
        public const string Scope = "scope";
        public const string GrantType = "grant_type";
        public const string ClientCredentialsGrant = "client_credentials";
        public const string TokenExchangeGrant = "urn:ietf:params:oauth:grant-type:token-exchange";
        public const string RequestedTokenType = "requested_token_type";
        public const string AccessTokenTokenType = "urn:ietf:params:oauth:token-type:access_token";
        public const string RequestedIssuer = "requested_issuer";
        public const string SubjectIssuer ="subject_issuer";
        public const string SubjectToken = "subject_token";
    }
}