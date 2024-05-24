using Flurl.Http;
using Keycloak.Net.Models.AuthenticationManagement;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        public async Task<IEnumerable<IDictionary<string, object>>> GetAuthenticatorProvidersAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/authenticator-providers")
            .GetJsonAsync<IEnumerable<IDictionary<string, object>>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<IEnumerable<IDictionary<string, object>>> GetClientAuthenticatorProvidersAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/client-authenticator-providers")
            .GetJsonAsync<IEnumerable<IDictionary<string, object>>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<AuthenticatorConfigInfo> GetAuthenticatorProviderConfigurationDescriptionAsync(string realm, string providerId, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/config-description/{providerId}")
            .GetJsonAsync<AuthenticatorConfigInfo>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        [Obsolete("Not working yet")]
        public async Task<AuthenticatorConfig> GetAuthenticatorConfigurationAsync(string realm, string configurationId, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/config/{configurationId}")
            .GetJsonAsync<AuthenticatorConfig>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<bool> UpdateAuthenticatorConfigurationAsync(string realm, string configurationId, AuthenticatorConfig authenticatorConfig, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/config/{configurationId}")
                .PutJsonAsync(authenticatorConfig, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAuthenticatorConfigurationAsync(string realm, string configurationId, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/config/{configurationId}")
                .DeleteAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> AddAuthenticationExecutionAsync(string realm, AuthenticationExecution authenticationExecution, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions")
                .PostJsonAsync(authenticationExecution, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<AuthenticationExecutionById> GetAuthenticationExecutionAsync(string realm, string executionId, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}")
            .GetJsonAsync<AuthenticationExecutionById>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<bool> DeleteAuthenticationExecutionAsync(string realm, string executionId, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}")
                .DeleteAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAuthenticationExecutionConfigurationAsync(string realm, string executionId, AuthenticatorConfig authenticatorConfig, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}/config")
                .PostJsonAsync(authenticatorConfig, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> LowerAuthenticationExecutionPriorityAsync(string realm, string executionId, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}/lower-priority")
                .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> RaiseAuthenticationExecutionPriorityAsync(string realm, string executionId, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/executions/{executionId}/raise-priority")
                .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> CreateAuthenticationFlowAsync(string realm, AuthenticationFlow authenticationFlow, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows")
                .PostJsonAsync(authenticationFlow, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<AuthenticationFlow>> GetAuthenticationFlowsAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/flows")
            .GetJsonAsync<IEnumerable<AuthenticationFlow>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<bool> DuplicateAuthenticationFlowAsync(string realm, string flowAlias, string newName, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/copy")
                .PostJsonAsync(new Dictionary<string, object> { [nameof(newName)] = newName }, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<AuthenticationFlowExecution>> GetAuthenticationFlowExecutionsAsync(string realm, string flowAlias, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions")
            .GetJsonAsync<IEnumerable<AuthenticationFlowExecution>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<bool> UpdateAuthenticationFlowExecutionsAsync(string realm, string flowAlias, AuthenticationExecutionInfo authenticationExecutionInfo, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions")
                .PutJsonAsync(authenticationExecutionInfo, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> AddAuthenticationFlowExecutionAsync(string realm, string flowAlias, IDictionary<string, object> dataWithProvider, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions/execution")
                .PostJsonAsync(dataWithProvider, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> AddAuthenticationFlowAndExecutionToAuthenticationFlowAsync(string realm, string flowAlias, IDictionary<string, object> dataWithAliasTypeProviderDescription, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowAlias}/executions/flow")
                .PostJsonAsync(dataWithAliasTypeProviderDescription, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<AuthenticationFlow> GetAuthenticationFlowByIdAsync(string realm, string flowId, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowId}")
            .GetJsonAsync<AuthenticationFlow>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<bool> UpdateAuthenticationFlowAsync(string realm, string flowId, AuthenticationFlow authenticationFlow, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowId}")
                .PutJsonAsync(authenticationFlow, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAuthenticationFlowAsync(string realm, string flowId, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/flows/{flowId}")
                .DeleteAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<IDictionary<string, object>>> GetFormActionProvidersAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/form-action-providers")
            .GetJsonAsync<IEnumerable<IDictionary<string, object>>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<IEnumerable<IDictionary<string, object>>> GetFormProvidersAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/form-providers")
            .GetJsonAsync<IEnumerable<IDictionary<string, object>>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<IDictionary<string, object>> GetConfigurationDescriptionsForAllClientsAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/per-client-config-description")
            .GetJsonAsync<IDictionary<string, object>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<bool> RegisterRequiredActionAsync(string realm, IDictionary<string, object> dataWithProviderIdName, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/register-required-action")
                .PostJsonAsync(dataWithProviderIdName, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<RequiredActionProvider>> GetRequiredActionsAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions")
            .GetJsonAsync<IEnumerable<RequiredActionProvider>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<RequiredActionProvider> GetRequiredActionByAliasAsync(string realm, string requiredActionAlias, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}")
            .GetJsonAsync<RequiredActionProvider>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);

        public async Task<bool> UpdateRequiredActionAsync(string realm, string requiredActionAlias, RequiredActionProvider requiredActionProvider, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}")
                .PutJsonAsync(requiredActionProvider, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteRequiredActionAsync(string realm, string requiredActionAlias, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}")
                .DeleteAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> LowerRequiredActionPriorityAsync(string realm, string requiredActionAlias, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}/lower-priority")
                .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> RaiseRequiredActionPriorityAsync(string realm, string requiredActionAlias, CancellationToken cancellationToken = default)
        {
            var response = await GetBaseUrl(realm)
                .AppendPathSegment($"/admin/realms/{realm}/authentication/required-actions/{requiredActionAlias}/raise-priority")
                .PostAsync(new StringContent(""), cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return response.ResponseMessage.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<IDictionary<string, object>>> GetUnregisteredRequiredActionsAsync(string realm, CancellationToken cancellationToken = default) => await GetBaseUrl(realm)
            .AppendPathSegment($"/admin/realms/{realm}/authentication/unregistered-required-actions")
            .GetJsonAsync<IEnumerable<IDictionary<string, object>>>(cancellationToken: cancellationToken)
            .ConfigureAwait(false);
    }
}
