using Flurl.Http;
using Keycloak.Net.Models.Users;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Keycloak.Net.Models;
using static Keycloak.Net.Constants;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<IEnumerable<UserCredential>> GetUserCredentialsAsync(string realm, string userId)
        {
            return await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials")
                .GetJsonAsync<IEnumerable<UserCredential>>()
                .ConfigureAwait(false);
        }

        public async Task<bool> UpdateUserCredentialAsync(string realm, string userId, string credentialId, string UserLabel)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials/{credentialId}/userLabel")
                .PutStringAsync(UserLabel)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteUserCredentialAsync(string realm, string userId, string credentialId)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials/{credentialId}")
                .DeleteAsync()
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<Response<bool>> ValidateUserCredentialsAsync(string realm, string clientId, string username, string password)
        {
            try
            {
                var response = await new Url(_url)
                    .AppendPathSegment(_options.Prefix)
                    .AppendPathSegment($"/realms/{realm}/protocol/openid-connect/token")
                    .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                    .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                    {
                        new(AuthKeywords.GrantType, AuthKeywords.Password),
                        new(AuthKeywords.ClientId, clientId),
                        new(AuthKeywords.Username, username),
                        new(AuthKeywords.Password, password),
                    })
                    .ConfigureAwait(false);

                return new Response<bool>(response.StatusCode, response.ResponseMessage.IsSuccessStatusCode);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<bool>(ex);
            }
        }
    }
}