using Newtonsoft.Json;

namespace Keycloak.Net.Models.AuthorizationResources
{
    public class AuthorizationResourceOwner
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}