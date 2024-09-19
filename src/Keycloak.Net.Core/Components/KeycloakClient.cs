using Keycloak.Net.Models.Components;

namespace Keycloak.Net;

public partial class KeycloakClient
{
	public async Task<bool> CreateComponentAsync(string realm,
												 Component componentRepresentation,
												 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/components")
											  .PostJsonAsync(componentRepresentation, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IEnumerable<Component>> GetComponentsAsync(string realm,
																 string? name = null,
																 string? parent = null,
																 string? type = null,
																 CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
						  {
							  [nameof(name)] = name,
							  [nameof(parent)] = parent,
							  [nameof(type)] = type
						  };

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/components")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<IEnumerable<Component>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}

	public async Task<Component> GetComponentAsync(string realm,
												   string componentId,
												   CancellationToken cancellationToken = default) =>
		await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/components/{componentId}")
							   .GetJsonAsync<Component>(cancellationToken: cancellationToken)
							   .ConfigureAwait(false);

	public async Task<bool> UpdateComponentAsync(string realm,
												 string componentId,
												 Component componentRepresentation,
												 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/components/{componentId}")
											  .PutJsonAsync(componentRepresentation, cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<bool> DeleteComponentAsync(string realm,
												 string componentId,
												 CancellationToken cancellationToken = default)
	{
		var response = await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/components/{componentId}")
											  .DeleteAsync(cancellationToken: cancellationToken)
											  .ConfigureAwait(false);
		return response.ResponseMessage.IsSuccessStatusCode;
	}

	public async Task<IEnumerable<ComponentType>> GetSubcomponentTypesAsync(string realm,
																			string componentId,
																			string? type = null,
																			CancellationToken cancellationToken = default)
	{
		var queryParams = new Dictionary<string, object?>
						  {
							  [nameof(type)] = type
						  };

		return await GetBaseUrl(realm).AppendPathSegment($"/admin/realms/{realm}/components/{componentId}/sub-component-types")
									  .SetQueryParams(queryParams)
									  .GetJsonAsync<IEnumerable<ComponentType>>(cancellationToken: cancellationToken)
									  .ConfigureAwait(false);
	}
}