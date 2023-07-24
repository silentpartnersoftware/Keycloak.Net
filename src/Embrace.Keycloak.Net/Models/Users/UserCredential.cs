namespace Keycloak.Net.Models.Users;

using Newtonsoft.Json;

public class UserCredential
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("credentialData")]
    public string CredentialData { get; set; }
    [JsonProperty("createdDate")]
    public long? CreatedDate { get; set; }
    [JsonProperty("temporary")]
    public bool? Temporary { get; set; }
    [JsonProperty("type")]
    public string Type { get; set; }
    [JsonProperty("userLabel")]
    public string UserLabel { get; set; }
    [JsonProperty("value")]
    public string Value { get; set; }
}