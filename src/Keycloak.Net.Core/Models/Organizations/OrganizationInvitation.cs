namespace Keycloak.Net.Models.Organizations;

public class OrganizationInvitation
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("organizationId")]
	public string? OrganizationId { get; set; }

	[JsonPropertyName("email")]
	public string? Email { get; set; }

	[JsonPropertyName("firstName")]
	public string? FirstName { get; set; }

	[JsonPropertyName("lastName")]
	public string? LastName { get; set; }

	[JsonPropertyName("sentDate")]
	public int? SentDate { get; set; }

	[JsonPropertyName("expiresAt")]
	public int? ExpiresAt { get; set; }

	[JsonPropertyName("status")]
	public string? Status { get; set; }

	[JsonPropertyName("inviteLink")]
	public string? InviteLink { get; set; }
}
