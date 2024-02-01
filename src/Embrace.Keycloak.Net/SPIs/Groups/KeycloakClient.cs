using Flurl.Http;
using Keycloak.Net.Models.Users;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Keycloak.Net.Models;
using Keycloak.Net.Models.Groups;
using static Keycloak.Net.Constants;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<Response<IEnumerable<Group>>> GetRootGroupsOnlyAsync(
            string realm,
            string search = null,
            bool? exact = false,
            int? first = null,
            int? max = null,
            bool? briefRepresentation = false)
        {
            Dictionary<string, object> queryParams = new()
            {
                [nameof(search)] = search,
                [nameof(exact)] = exact,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(briefRepresentation)] = briefRepresentation
            };

            try
            {
                var groups = await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/spi-groups")
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<IEnumerable<Group>>()
                    .ConfigureAwait(false);

                return Response<IEnumerable<Group>>.Success(HttpStatusCode.OK, groups);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<IEnumerable<Group>>(ex);
            }
        }

        public async Task<Response<Group>> GetGroupOnlyAsync(string realm, string groupId)
        {
            try
            {
                var group = await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/spi-groups/{groupId}")
                    .GetJsonAsync<Group>()
                    .ConfigureAwait(false);

                return Response<Group>.Success(HttpStatusCode.OK, group);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<Group>(ex);
            }
        }

        public async Task<Response<IEnumerable<Group>>> GetGroupSubgroupsOnlyAsync(
            string realm,
            string groupId,
            string search = null,
            bool? exact = false,
            int? first = null,
            int? max = null,
            bool? briefRepresentation = false)
        {
            Dictionary<string, object> queryParams = new()
            {
                [nameof(search)] = search,
                [nameof(exact)] = exact,
                [nameof(first)] = first,
                [nameof(max)] = max,
                [nameof(briefRepresentation)] = briefRepresentation
            };

            try
            {
                var groups = await GetBaseUrl(realm)
                    .AppendPathSegment($"/realms/{realm}/spi-groups/{groupId}/subgroups")
                    .SetQueryParams(queryParams)
                    .GetJsonAsync<IEnumerable<Group>>()
                    .ConfigureAwait(false);

                return Response<IEnumerable<Group>>.Success(HttpStatusCode.OK, groups);
            }
            catch (FlurlHttpException ex)
            {
                return await HandleErrorResponse<IEnumerable<Group>>(ex);
            }
        }
    }
}