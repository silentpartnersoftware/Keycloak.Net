using Newtonsoft.Json;

namespace Keycloak.Net.Models.ClientScopes
{
    public class Attributes
    {
        [JsonProperty("consent.screen.text")]
        public string ConsentScreenText { get; set; }
        [JsonProperty("display.on.consent.screen")]
        public string DisplayOnConsentScreen { get; set; }
        [JsonProperty("include.in.token.scope")]
        public string IncludeInTokenScope { get; set; }
        [JsonProperty("gui.order")]
        public string DisplayOrder { get; set; }
    }
}