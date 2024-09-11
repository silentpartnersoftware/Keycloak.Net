using Keycloak.Net.Models.Groups;
using Keycloak.Net.Models.Users;
using System;
using System.Net.Http;

namespace Keycloak.Net;

public partial class KeycloakClient
{
	public async Task<bool> CreateUserAsync(string realm, User user, CancellationToken cancellationToken = default)
	{
		var response = await InternalCreateUserAsync(realm, user, cancellationToken: cancellationToken).ConfigureAwait(false);
		return response.IsSuccessStatusCode;
	}

	private async Task<HttpResponseMessage> InternalCreateUserAsync(string realm,
																	User user,
																	CancellationToken cancellationToken) =>
		(await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users")
								.PostJsonAsync(user, cancellationToken: cancellationToken)
								.ConfigureAwait(false)).ResponseMessage;

	public async Task<string?> CreateAndRetrieveUserIdAsync(string realm,
															User user,
															CancellationToken cancellationToken = default)
	{
		var response = await InternalCreateUserAsync(realm,
													 user,
													 cancellationToken: cancellationToken)
						   .ConfigureAwait(false);
		var locationPathAndQuery = response.Headers
										   .Location!
										   .PathAndQuery;
		var userId = response.IsSuccessStatusCode
						 ? locationPathAndQuery[(locationPathAndQuery.LastIndexOf("/", StringComparison.Ordinal) + 1)..]
						 : null;
		return userId;
	}

	public async Task<IEnumerable<User>> GetUsersAsync(string realm,
													   bool? briefRepresentation = null,
													   string? email = null,
													   bool? emailVerified = null,
													   bool? enabled = null,
													   bool? exact = null,
													   int? first = null,
													   string? firstName = null,
													   string? idpAlias = null,
													   string? idpUserId = null,
													   string? lastName = null,
													   int? max = null,
													   string? q = null,
													   string? search = null,
													   string? username = null,
													   CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
						  {
							  [nameof(briefRepresentation)] = briefRepresentation,
							  [nameof(email)] = email,
							  [nameof(emailVerified)] = emailVerified,
							  [nameof(enabled)] = enabled,
							  [nameof(exact)] = exact,
							  [nameof(first)] = first,
							  [nameof(firstName)] = firstName,
							  [nameof(idpAlias)] = idpAlias,
							  [nameof(idpUserId)] = idpUserId,
							  [nameof(lastName)] = lastName,
							  [nameof(max)] = max,
							  [nameof(q)] = q,
							  [nameof(search)] = search,
							  [nameof(username)] = username,
						  };

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<IEnumerable<User>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<int> GetUsersCountAsync(string realm,
											  string? email = null,
											  bool? emailVerified = null,
											  bool? enabled = null,
											  string? firstName = null,
											  string? lastName = null,
											  string? q = null,
											  string? search = null,
											  string? username = null,
											  CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
						  {
							  [nameof(email)] = email,
							  [nameof(emailVerified)] = emailVerified,
							  [nameof(enabled)] = enabled,
							  [nameof(firstName)] = firstName,
							  [nameof(lastName)] = lastName,
							  [nameof(q)] = q,
							  [nameof(search)] = search,
							  [nameof(username)] = username,
						  };

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/count")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<int>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<User> GetUserAsync(string realm,
										 string userId,
										 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
							   .GetJsonAsync<User>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> UpdateUserAsync(string realm,
											string userId,
											User user,
											CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
											  .PutJsonAsync(user, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteUserAsync(string realm,
											string userId,
											CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	[Obsolete("Not working yet")]
	public async Task<string> GetUserConsentsAsync(string realm,
												   string userId,
												   CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/consents")
							   .GetStringAsync(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> RevokeUserConsentAndOfflineTokensAsync(string realm,
																   string userId,
																   string clientId,
																   CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/consents/{clientId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IEnumerable<Credentials>> GetUserCredentialsAsync(string realm,
																		string userId,
																		CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/credentials")
							   .GetJsonAsync<IEnumerable<Credentials>>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> DisableUserCredentialsAsync(string realm,
														string userId,
														IEnumerable<string> credentialTypes,
														CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm)
							 .AppendPathSegment($"/admin/realms/{realm}/users/{userId}/disable-credential-types")
							 .PutJsonAsync(credentialTypes, cancellationToken: cancellationToken)
							 .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> SendUserUpdateAccountEmailAsync(string realm,
															string userId,
															IEnumerable<string> requiredActions,
															string? clientId = null,
															int? lifespan = null,
															string? redirectUri = null,
															CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
						  {
							  ["client_id"] = clientId,
							  [nameof(lifespan)] = lifespan,
							  ["redirect_uri"] = redirectUri
						  };

		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/execute-actions-email")
											  .SetQueryParams(queryParams)
											  .PutJsonAsync(requiredActions, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IEnumerable<FederatedIdentity>> GetUserSocialLoginsAsync(string realm,
																			   string userId,
																			   CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity")
							   .GetJsonAsync<IEnumerable<FederatedIdentity>>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> AddUserSocialLoginProviderAsync(string realm,
															string userId,
															string provider,
															FederatedIdentity federatedIdentity,
															CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity/{provider}")
											  .PostJsonAsync(federatedIdentity, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> RemoveUserSocialLoginProviderAsync(string realm,
															   string userId,
															   string provider,
															   CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/federated-identity/{provider}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IEnumerable<Group>> GetUserGroupsAsync(string realm,
															 string userId,
															 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups")
							   .GetJsonAsync<IEnumerable<Group>>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<int> GetUserGroupsCountAsync(string realm,
												   string userId,
												   CancellationToken cancellationToken = default)
	{
		var result = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/count")
											.GetJsonAsync<CountDto>(cancellationToken: cancellationToken)
											.ConfigureAwait(false);
		return result.Count;
	}

	public async Task<bool> UpdateUserGroupAsync(string realm,
												 string userId,
												 string groupId,
												 Group group,
												 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/{groupId}")
											  .PutJsonAsync(group, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteUserGroupAsync(string realm,
												 string userId,
												 string groupId,
												 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/groups/{groupId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IDictionary<string, object>> ImpersonateUserAsync(string realm,
																		string userId,
																		CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/impersonation")
							   .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
							   .ReceiveJson<IDictionary<string, object>>()
							   .ConfigureAwait(false);

	public async Task<bool> RemoveUserSessionsAsync(string realm,
													string userId,
													CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/logout")
											  .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	[Obsolete("Not working yet")]
	public async Task<IEnumerable<UserSession>> GetUserOfflineSessionsAsync(string realm,
																			string userId,
																			string clientId,
																			CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/offline-sessions/{clientId}")
							   .GetJsonAsync<IEnumerable<UserSession>>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> RemoveUserTotpAsync(string realm,
												string userId,
												CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/remove-totp")
											  .PutAsync(new StringContent(""), cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> ResetUserPasswordAsync(string realm,
												   string userId,
												   Credentials credentials,
												   CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/reset-password")
											  .PutJsonAsync(credentials, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> ResetUserPasswordAsync(string realm,
												   string userId,
												   string password,
												   bool temporary = true,
												   CancellationToken cancellationToken = default)
	{
		var response = await InternalResetUserPasswordAsync(realm,
															userId,
															password,
															temporary,
															cancellationToken).ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	private async Task<IFlurlResponse> InternalResetUserPasswordAsync(string realm,
																		   string userId,
																		   string password,
																		   bool temporary,
																		   CancellationToken cancellationToken) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/reset-password")
							   .PutJsonAsync(new Credentials
											 {
												 Value = password,
												 Temporary = temporary
											 }, cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<SetPasswordResponse> SetUserPasswordAsync(string realm,
																string userId,
																string password,
																CancellationToken cancellationToken = default)
	{
		var response = await InternalResetUserPasswordAsync(realm,
															userId,
															password,
															false,
															cancellationToken);
		return response.ResponseMessage.IsSuccessStatusCode
				   ? new() { Success = response.ResponseMessage.IsSuccessStatusCode }
				   : await response.GetJsonAsync<SetPasswordResponse>();
	}

	public async Task<bool> VerifyUserEmailAddressAsync(string realm,
														string userId,
														string? clientId = null,
														string? redirectUri = null,
														CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object>();
		if (!string.IsNullOrEmpty(clientId))
			queryParams.Add("client_id", clientId);
		
		if (!string.IsNullOrEmpty(redirectUri))
			queryParams.Add("redirect_uri", redirectUri);

		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/send-verify-email")
											  .SetQueryParams(queryParams)
											  .PutJsonAsync(null, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IEnumerable<UserSession>> GetUserSessionsAsync(string realm,
																	 string userId,
																	 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/users/{userId}/sessions")
							   .GetJsonAsync<IEnumerable<UserSession>>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);
}