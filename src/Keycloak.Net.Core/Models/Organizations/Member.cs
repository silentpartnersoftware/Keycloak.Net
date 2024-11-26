using Keycloak.Net.Models.Users;

namespace Keycloak.Net.Models.Organizations;

public class Member : User
{
    [JsonPropertyName("membershipType")]
    public MembershipType? MembershipType { get; set; }
}