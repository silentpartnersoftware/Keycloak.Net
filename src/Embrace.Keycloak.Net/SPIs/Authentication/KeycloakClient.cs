using Flurl.Http;
using Keycloak.Net.Models;
using Keycloak.Net.Models.TokenExchange;
using Keycloak.Net.SPIs.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using static Keycloak.Net.Constants;

namespace Keycloak.Net;

public partial class KeycloakClient
{
    public async Task<Response<bool>> NativeSignIn(string email)
    {
        try
        {
            const string realm = "embracecloud";
            await GetBaseUrl(realm)
                .AppendPathSegment($"/realms/{realm}/spi-authentication/native-sign-in")
                .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("email", email)
                })
                .ConfigureAwait(false);

            return Response<bool>.Success(HttpStatusCode.OK, true);
        }
        catch (FlurlHttpException ex)
        {
            return await HandleErrorResponse<bool>(ex);
        }
    }

    public async Task<Response<bool>> InviteMember(string realm, string email, string redirectUri, bool isExternalManaged = false, string suiteName = null)
    {
        try
        {
            await GetBaseUrl(realm)
                .AppendPathSegment($"/realms/{realm}/spi-authentication/invite-member")
                .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("email", email),
                    new("redirect_uri", redirectUri),
                    new("external_managed", isExternalManaged.ToString()),
                    new("suite_name", suiteName)
                })
                .ConfigureAwait(false);

            return Response<bool>.Success(HttpStatusCode.OK, true);
        }
        catch (FlurlHttpException ex)
        {
            return await HandleErrorResponse<bool>(ex);
        }
    }

    public async Task<Response<MicrosoftToken>> ExchangeForMicrosoftTokenAsync(
        string realm,
        string accessToken,
        string idpAlias,
        MicrosoftExchangeTokenType type)
    {
        try
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/realms/{realm}/spi-authentication/exchange-ms-token")
                .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new(AuthKeywords.IdpAlias, idpAlias),
                    new(AuthKeywords.AccessToken, accessToken),
                    new(AuthKeywords.TokenType, Enum.GetName(type))
                })
                .ReceiveJson<MicrosoftToken>()
                .ConfigureAwait(false);

            return Response<MicrosoftToken>.Success(HttpStatusCode.OK, response);
        }
        catch (FlurlHttpException ex)
        {
            return await HandleErrorResponse<MicrosoftToken>(ex);
        }
    }

    public async Task<Response<MicrosoftToken>> FetchSystemTokenAsync(string realm, string tenantId)
    {
        try
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/realms/{realm}/spi-authentication/system-token")
                .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                {
                    new("tenant_id", tenantId)
                })
                .ReceiveJson<MicrosoftToken>()
                .ConfigureAwait(false);

            return Response<MicrosoftToken>.Success(HttpStatusCode.OK, response);
        }
        catch (FlurlHttpException ex)
        {
            return await HandleErrorResponse<MicrosoftToken>(ex);
        }
    }
}