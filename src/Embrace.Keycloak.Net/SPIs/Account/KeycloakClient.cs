using Flurl.Http;
using Keycloak.Net.Models.Users;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Keycloak.Net.Models;
using Keycloak.Net.Models.Account;
using static Keycloak.Net.Constants;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<Response<bool>> ChangeEmailAsync(string realm, string newEmailAddress)
        {
            string url = $"/realms/{realm}/spi-account/change-email";
            return await InternalChangeEmailAsync(url, realm, newEmailAddress);
        }

        public async Task<Response<bool>> ChangeEmailForUserAsync(string realm, string userId, string newEmailAddress)
        {
            string url = $"/realms/{realm}/spi-account/users/{userId}/change-email";
            return await InternalChangeEmailAsync(url, realm, newEmailAddress);
        }

        private async Task<Response<bool>> InternalChangeEmailAsync(string url, string realm, string newEmailAddress)
        {
            try
            {
                await GetBaseUrl(realm)
                    .AppendPathSegment(url)
                    .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                    .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                    {
                        new("email", newEmailAddress)
                    })
                    .ConfigureAwait(false);

                return Response<bool>.Success(HttpStatusCode.OK, true);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<bool>(ex);
            }
        }

        public async Task<Response<MfaCode>> GetMfaCodeAsync(string realm, string userId)
        {
            try
            {
                var mfaCode = await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/spi-account/users/{userId}/mfa")
                    .GetJsonAsync<MfaCode>()
                    .ConfigureAwait(false);

                return Response<MfaCode>.Success(HttpStatusCode.OK, mfaCode);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<MfaCode>(ex);
            }
        }

        public async Task<Response<bool>> RegisterMfaDeviceAsync(string realm, string userId, string deviceName, string code, string secret)
        {
            try
            {
                await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/spi-account/users/{userId}/mfa")
                    .PostJsonAsync(new
                    {
                        deviceName = deviceName,
                        totpInitialCode = code,
                        encodedTotpSecret = secret,
                        overwrite = false
                    })
                    .ConfigureAwait(false);

                return Response<bool>.Success(HttpStatusCode.OK, true);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<bool>(ex);
            }
        }

        public async Task<Response<bool>> ValidateMfaCodeAsync(string realm, string userId, string deviceName, string code)
        {
            try
            {
                await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/spi-account/users/{userId}/mfa/validate")
                    .PostJsonAsync(new
                    {
                        deviceName = deviceName,
                        totpCode = code
                    })
                    .ConfigureAwait(false);

                return Response<bool>.Success(HttpStatusCode.OK, true);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<bool>(ex);
            }
        }
        
        public async Task<Response<bool>> SendReminderEmail(string realm, string userId, string link, string themeId = null)
        {
            try
            {
                await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/spi-account/users/{userId}/send-reminder")
                    .WithHeader(HttpConstants.ContentType, HttpConstants.FormUrlEncoded)
                    .SetQueryParam("theme_id", themeId)
                    .PostUrlEncodedAsync(new List<KeyValuePair<string, string>>
                    {
                        new("link", link)
                    })
                    .ConfigureAwait(false);

                return Response<bool>.Success(HttpStatusCode.OK, true);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<bool>(ex);
            }
        }
    }
}