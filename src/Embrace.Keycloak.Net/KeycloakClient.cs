using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Keycloak.Net.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;
using Flurl.Http.Newtonsoft;
using Keycloak.Net.Models;

namespace Keycloak.Net
{
    public partial class KeycloakClient
    {
        private ISerializer _serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore
        });

        private readonly Url _url;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _clientSecret;
        private readonly Func<string> _getToken;
        private readonly ForwardedHttpHeaders _forwardedHeaders;
        private readonly KeycloakOptions _options;

        private KeycloakClient(string url, KeycloakOptions options)
        {
            _url = url;
            _options = options ?? new KeycloakOptions();
        }

        public KeycloakClient(string url, string userName, string password, KeycloakOptions options = null)
            : this(url, options)
        {
            _userName = userName;
            _password = password;
        }

        public KeycloakClient(string url, string clientSecret, KeycloakOptions options = null)
            : this(url, options)
        {
            _clientSecret = clientSecret;
        }

        public KeycloakClient(string url, Func<string> getToken, KeycloakOptions options = null)
            : this(url, options)
        {
            _getToken = getToken;
        }
        
        public KeycloakClient(string url, Func<string> getToken, ForwardedHttpHeaders forwardedHeaders, KeycloakOptions options = null)
            : this(url, options)
        {
            _getToken = getToken;
            _forwardedHeaders = forwardedHeaders;
        }

        public void SetSerializer(ISerializer serializer)
        {
            _serializer = serializer ?? throw new ArgumentNullException(nameof(serializer));
        }

        private IFlurlRequest GetBaseUrl(string authenticationRealm)
        {
            // Uncomment the line below when using admin-cli client to authenticate:
            // authenticationRealm = "master";
            // TODO: Find a proper way to configure this  
            
            var request = new Url(_url)
                .AppendPathSegment(_options.Prefix)
                .WithSettings(s => s.JsonSerializer = _serializer)
                .WithAuthentication(_getToken, _url, authenticationRealm, _userName, _password, _clientSecret, _options);

            if (_forwardedHeaders != null)
                request.WithForwardedHttpHeaders(_forwardedHeaders);

            return request;
        }
        
        public async Task<Response<T>> HandleErrorResponse<T>(FlurlHttpException ex)
        {
            if (ex.Call.Response == null)
            {
                return Response<T>.Failure(HttpStatusCode.InternalServerError, ex.Call.Exception.Message);
            }

            var kcStatus = ex.Call.Response.StatusCode;
            ex.Call.Response.Headers.TryGetFirst("Content-Type", out string contentType);
            KeycloakErrorResponse kcError;

            if (contentType.Contains("application/json"))
            {
                kcError = await ex.GetResponseJsonAsync<KeycloakErrorResponse>();
            }
            else
            {
                kcError = new KeycloakErrorResponse()
                {
                    ErrorCode = await ex.GetResponseStringAsync()
                };
            }

            return Response<T>.Failure(kcStatus, $"{kcStatus} | {kcError.ErrorDetails}");
        }
    }

    public class KeycloakOptions
    {
        public string Prefix { get; }
        public string AdminClientId { get; }

        public KeycloakOptions(string prefix = "", string adminClientId = "admin-cli")
        {
            Prefix = prefix.TrimStart('/').TrimEnd('/');
            AdminClientId = adminClientId;
        }
    }
}