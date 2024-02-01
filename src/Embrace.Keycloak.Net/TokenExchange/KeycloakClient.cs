using System.Collections.Generic;
using System.Net;
using Flurl.Http;
using System.Threading.Tasks;
using Keycloak.Net.Models;
using Keycloak.Net.Models.TokenExchange;
using static Keycloak.Net.Constants;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<Response<ExternalIdpToken>> ExchangeForExternalTokenAsync(
            string realm,
            string keycloakToken,
            string idpName,
            string clientId = null,
            string clientSecret = null)
        {
            try
            {
                var response = await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/token")
                    .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                    .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                    {
                        new(AuthKeywords.GrantType, AuthKeywords.TokenExchangeGrant),
                        new(AuthKeywords.RequestedTokenType, AuthKeywords.AccessTokenTokenType),
                        new(AuthKeywords.RequestedIssuer, idpName),
                        new(AuthKeywords.SubjectToken, keycloakToken),
                        new(AuthKeywords.ClientId, clientId),
                        new(AuthKeywords.ClientSecret, clientSecret)
                    })
                    .ReceiveJson<ExternalIdpToken>()
                    .ConfigureAwait(false);

                return Response<ExternalIdpToken>.Success(HttpStatusCode.OK, response);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<ExternalIdpToken>(ex);
            }
        }
    }
}