using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http;
using Keycloak.Net.Models;

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
                .WithHeader(Constants.HttpConstants.ContentType, Constants.HttpConstants.FormUrlEncoded)
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
}