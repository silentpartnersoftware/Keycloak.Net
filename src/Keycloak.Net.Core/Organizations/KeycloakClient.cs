using System;
using System.Linq;
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
																CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
		{
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
																		 string memberId,
																		 CancellationToken cancellationToken = default)
	{
		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/organizations/members/{memberId}/organizations")
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