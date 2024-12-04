using System;

namespace Keycloak.Net.Core.Models.Organizations;

public class OrganizationDomain
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("verified")]
    public bool? Verified { get; set; }
}
