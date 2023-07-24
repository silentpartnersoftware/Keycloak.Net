using Newtonsoft.Json;

namespace Keycloak.Net.Models
{
    public class KeycloakErrorResponse
    {
        [JsonProperty("error")]
        public string ErrorCode { get; init; }

        [JsonProperty("errorMessage")]
        public string ErrorMessage { private get; init; }

        [JsonProperty("error_description")]
        public string ErrorDescription { private get; init; }

        public string ErrorDetails
        {
            get
            {
                if (!string.IsNullOrEmpty(ErrorMessage))
                    return ErrorMessage;

                if (!string.IsNullOrEmpty(ErrorDescription))
                    return ErrorDescription;

                return ErrorCode;
            }
        }
    }
}
