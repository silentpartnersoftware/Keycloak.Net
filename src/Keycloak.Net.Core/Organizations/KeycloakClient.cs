using System;
using System.Linq;
using Keycloak.Net.Models.Groups;
using Keycloak.Net.Models.IdentityProviders;
using Keycloak.Net.Models.Organizations;

namespace Keycloak.Net;

public partial class KeycloakClient
{
	public async Task<List<Organization>> GetOrganizationsAsync(string realm,
																bool? exact = null,
																int? first = null,
																int? max = null,
																string? q = null,
																string? search = null,
                                                                bool? briefRepresentation = null,
																CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
            [nameof(briefRepresentation)] = briefRepresentation,
			[nameof(exact)] = exact,
			[nameof(first)] = first,
			[nameof(max)] = max,
			[nameof(q)] = q,
			[nameof(search)] = search
		};
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations")
											  .SetQueryParams(queryParams)
											  .GetJsonAsync<List<Organization>>(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response;
	}

	public async Task<bool> DeleteOrganizationAsync(string realm,
													string organizationId,
													CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<Organization> GetOrganizationAsync(string realm,
														 string organizationId,
														 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}")
							   .GetJsonAsync<Organization>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> UpdateOrganizationAsync(string realm,
													string organizationId,
													Organization organization,
													CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}")
											  .PutJsonAsync(organization, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;

	}

	public async Task<string> CreateOrganizationAsync(string realm,
												    Organization organization,
												    CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations")
											  .PostJsonAsync(organization, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		
		return GetResourceIdentifierFromLocation(response.ResponseMessage.Headers.Location);
	}

	private static string GetResourceIdentifierFromLocation(Uri? location)
	{
		return location?.Segments.LastOrDefault() ?? throw new InvalidOperationException($"\"{nameof(location)}\" is invalid.");
	}

	public async Task<long> GetOrganizationsCountAsync(string realm,
													   bool? exact = null,
													   string? q = null,
													   string? search = null,
													   CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(exact)] = exact,
			[nameof(q)] = q,
			[nameof(search)] = search
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/count")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<long>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<List<Group>> GetOrganizationGroupsAsync(string realm,
															  string organizationId,
															  bool? briefRepresentation = null,
															  bool? exact = null,
															  int? first = null,
															  int? max = null,
															  bool? populateHierarchy = null,
															  string? q = null,
															  string? search = null,
															  bool? subGroupsCount = null,
															  CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(briefRepresentation)] = briefRepresentation,
			[nameof(exact)] = exact,
			[nameof(first)] = first,
			[nameof(max)] = max,
			[nameof(populateHierarchy)] = populateHierarchy,
			[nameof(q)] = q,
			[nameof(search)] = search,
			[nameof(subGroupsCount)] = subGroupsCount
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<List<Group>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<bool> CreateOrganizationGroupAsync(string realm,
														 string organizationId,
														 Group group,
														 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups")
											  .PostJsonAsync(group, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<Group> GetOrganizationGroupByPathAsync(string realm,
															 string organizationId,
															 string path,
															 bool? subGroupsCount = null,
															 CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(subGroupsCount)] = subGroupsCount
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/group-by-path/{path}")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<Group>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<Group> GetOrganizationGroupAsync(string realm,
													   string organizationId,
													   string groupId,
													   bool? subGroupsCount = null,
													   CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(subGroupsCount)] = subGroupsCount
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<Group>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<bool> UpdateOrganizationGroupAsync(string realm,
														 string organizationId,
														 string groupId,
														 Group group,
														 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}")
											  .PutJsonAsync(group, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteOrganizationGroupAsync(string realm,
														 string organizationId,
														 string groupId,
														 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<List<Group>> GetOrganizationGroupChildrenAsync(string realm,
																	 string organizationId,
																	 string groupId,
																	 bool? exact = null,
																	 int? first = null,
																	 int? max = null,
																	 string? search = null,
																	 bool? subGroupsCount = null,
																	 CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(exact)] = exact,
			[nameof(first)] = first,
			[nameof(max)] = max,
			[nameof(search)] = search,
			[nameof(subGroupsCount)] = subGroupsCount
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}/children")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<List<Group>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<bool> SetOrCreateOrganizationGroupChildAsync(string realm,
																   string organizationId,
																   string groupId,
																   Group group,
																   CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}/children")
											  .PostJsonAsync(group, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<List<Member>> GetOrganizationGroupMembersAsync(string realm,
																	 string organizationId,
																	 string groupId,
																	 bool? briefRepresentation = null,
																	 int? first = null,
																	 int? max = null,
																	 CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(briefRepresentation)] = briefRepresentation,
			[nameof(first)] = first,
			[nameof(max)] = max
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}/members")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<List<Member>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<bool> AddOrganizationGroupMemberAsync(string realm,
															string organizationId,
															string groupId,
															string userId,
															CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}/members/{userId}")
											  .PutJsonAsync(null, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteOrganizationGroupMemberAsync(string realm,
															   string organizationId,
															   string groupId,
															   string userId,
															   CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/groups/{groupId}/members/{userId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteOrganizationIdentityProviderAsync(string realm,
																	string organizationId,
																	string identityProviderAlias,
																	CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/identity-providers/{identityProviderAlias}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IdentityProvider> GetOrganizationIdentityProviderAsync(string realm,
																			 string organizationId,
																			 string identityProviderAlias,
																			 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/identity-providers/{identityProviderAlias}")
							   .GetJsonAsync<IdentityProvider>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<List<IdentityProvider>> GetOrganizationIdentityProvidersAsync(string realm,
																					string organizationId,
																					CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/identity-providers")
							   .GetJsonAsync<List<IdentityProvider>>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);
	
	public async Task<bool> AddOrganizationIdentityProviderAsync(string realm,
																 string organizationId,
																 string identityProviderId,
																 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/identity-providers")
											  .PostJsonAsync(identityProviderId, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<List<Group>> GetOrganizationIdentityProviderGroupsAsync(string realm,
																			  string organizationId,
																			  string identityProviderAlias,
																			  bool? briefRepresentation = null,
																			  bool? exact = null,
																			  int? first = null,
																			  int? max = null,
																			  string? q = null,
																			  string? search = null,
																			  bool? subGroupsCount = null,
																			  CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(briefRepresentation)] = briefRepresentation,
			[nameof(exact)] = exact,
			[nameof(first)] = first,
			[nameof(max)] = max,
			[nameof(q)] = q,
			[nameof(search)] = search,
			[nameof(subGroupsCount)] = subGroupsCount
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/identity-providers/{identityProviderAlias}/groups")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<List<Group>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<List<OrganizationInvitation>> GetOrganizationInvitationsAsync(string realm,
																					string organizationId,
																					string? email = null,
																					int? first = null,
																					string? firstName = null,
																					string? lastName = null,
																					int? max = null,
																					string? search = null,
																					string? status = null,
																					CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(email)] = email,
			[nameof(first)] = first,
			[nameof(firstName)] = firstName,
			[nameof(lastName)] = lastName,
			[nameof(max)] = max,
			[nameof(search)] = search,
			[nameof(status)] = status
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/invitations")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<List<OrganizationInvitation>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<OrganizationInvitation> GetOrganizationInvitationAsync(string realm,
																			 string organizationId,
																			 string invitationId,
																			 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/invitations/{invitationId}")
							   .GetJsonAsync<OrganizationInvitation>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> DeleteOrganizationInvitationAsync(string realm,
															  string organizationId,
															  string invitationId,
															  CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/invitations/{invitationId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> ResendOrganizationInvitationAsync(string realm,
															  string organizationId,
															  string invitationId,
															  CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/invitations/{invitationId}/resend")
											  .PostJsonAsync(null, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<long> GetOrganizationMembersCountAsync(string realm,
															 string organizationId,
															 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/count")
							   .GetJsonAsync<long>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<List<Member>> GetOrganizationMembersAsync(string realm,
																string organizationId,
																bool? exact = null,
																int? first = null,
																int? max = null,
																string? search = null,
																CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(exact)] = exact,
			[nameof(first)] = first,
			[nameof(max)] = max,
			[nameof(search)] = search
		};
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members")
											  .SetQueryParams(queryParams)
											  .GetJsonAsync<List<Member>>(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response;

	}

	public async Task<List<Member>> GetOrganizationMembersByMembershipTypeAsync(string realm,
																				string organizationId,
																				string membershipType,
																				bool? exact = null,
																				int? first = null,
																				int? max = null,
																				string? search = null,
																				CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(exact)] = exact,
			[nameof(first)] = first,
			[nameof(max)] = max,
			[nameof(membershipType)] = membershipType,
			[nameof(search)] = search
		};
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members")
											  .SetQueryParams(queryParams)
											  .GetJsonAsync<List<Member>>(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response;

	}

	public async Task<Member> GetOrganizationMemberAsync(string realm,
														 string organizationId,
														 string memberId,
														 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/{memberId}")
							   .GetJsonAsync<Member>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> DeleteMemberFromOrganizationAsync(string realm,
															  string organizationId,
															  string memberId,
															  CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/{memberId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);

		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<List<Organization>> GetOrganizationsForMemberAsync(string realm,
																		 string organizationId,
																		 string memberId,
																		 CancellationToken cancellationToken = default)
	{
		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/{memberId}/organizations")
									  .GetJsonAsync<List<Organization>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<List<Organization>> GetOrganizationsForMemberAsync(string realm,
																		 string organizationId,
																		 string memberId,
																		 bool? briefRepresentation = null,
																		 CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(briefRepresentation)] = briefRepresentation,
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/{memberId}/organizations")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<List<Organization>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<List<Group>> GetOrganizationMemberGroupsAsync(string realm,
																	string organizationId,
																	string memberId,
																	bool? briefRepresentation = null,
																	int? first = null,
																	int? max = null,
																	string? search = null,
																	CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
			[nameof(briefRepresentation)] = briefRepresentation,
			[nameof(first)] = first,
			[nameof(max)] = max,
			[nameof(search)] = search
		};

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/{memberId}/groups")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<List<Group>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<List<Organization>> GetOrganizationsForMemberAsync(string realm,
																		 string memberId,
                                                                         bool? briefRepresentation = null,
																		 CancellationToken cancellationToken = default)
	{
        var queryParams = new Dictionary<string, object?>
        {
            [nameof(briefRepresentation)] = briefRepresentation,
        };
		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/members/{memberId}/organizations")
                                      .SetQueryParams(queryParams)
									  .GetJsonAsync<List<Organization>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<bool> AddMemberToOrganizationAsync(string realm,
														 string organizationId,
														 string userId,
														 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members")
											  .PostJsonAsync(userId, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	/// <summary>
	/// Invites an existing user to the organization, using the specified user id.
	/// </summary>
	/// <param name="realm"></param>
	/// <param name="organizationId"></param>
	/// <param name="userId"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<bool> InviteUserToOrganizationAsync(string realm,
														  string organizationId,
														  string userId,
														  CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/invite-existing-user")
											  .PostMultipartAsync(form => form.AddString("id", userId), 
																  cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	/// <summary>
	/// Invites an existing user or sends a registration link to a new user, based on the provided e-mail address.
	/// </summary>
	/// <param name="realm"></param>
	/// <param name="organizationId"></param>
	/// <param name="email"></param>
	/// <param name="firstName"></param>
	/// <param name="lastName"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <remarks>If the user with the given e-mail address exists, it sends an invitation link, otherwise it sends a registration link.</remarks>
	public async Task<bool> InviteUserToOrganizationAsync(string realm,
														  string organizationId,
														  string email,
														  string? firstName = null,
														  string? lastName = null,
														  CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/{organizationId}/members/invite-user")
											  .PostMultipartAsync(form => form
																		  .AddString(nameof(email), email)
																		  .AddString(nameof(firstName), firstName)
																		  .AddString(nameof(lastName), lastName), 
																  cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}
}
