using Newtonsoft.Json;

namespace Keycloak.Net.Models.Account
{
    public class MfaCode
    {
        [JsonProperty("encodedTotpSecret")]
        public string EncodedTotpSecret { get; set; }
        [JsonProperty("totpSecretQRCode")]
        public string TotpSecretQRCode { get; set; }
    }
}
