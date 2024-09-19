using Keycloak.Net.Models.AuthorizationScopes;

namespace Keycloak.Net;

public partial class KeycloakClient
{
	public async Task<string> CreateAuthorizationScopeAsync(string realm,
															string resourceServerId,
															AuthorizationScope scope,
															CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/scope")
											  .PostJsonAsync(scope, cancellationToken: cancellationToken)
											  .ReceiveJson<AuthorizationScope>()
											  .ConfigureAwait(false);
		return response.Id;
	}

	public async Task<IEnumerable<AuthorizationScope>> GetAuthorizationScopesAsync(string realm,
																				   string? resourceServerId = null,
																				   bool deep = false,
																				   int? first = null,
																				   int? max = null,
																				   string? name = null,
																				   CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
						  {
							  [nameof(deep)] = deep,
							  [nameof(first)] = first,
							  [nameof(max)] = max,
							  [nameof(name)] = name,
						  };

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/scope")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<IEnumerable<AuthorizationScope>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<AuthorizationScope> GetAuthorizationScopeAsync(string realm,
																	 string resourceServerId,
																	 string scopeId,
																	 CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/scope/{scopeId}")
							   .GetJsonAsync<AuthorizationScope>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> UpdateAuthorizationScopeAsync(string realm,
														  string resourceServerId,
														  string scopeId,
														  AuthorizationScope scope,
														  CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/scope/{scopeId}")
											  .PutJsonAsync(scope, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteAuthorizationScopeAsync(string realm,
														  string resourceServerId,
														  string scopeId,
														  CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/clients/{resourceServerId}/authz/resource-server/scope/{scopeId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}
}