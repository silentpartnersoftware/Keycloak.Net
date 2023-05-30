using System;
using Keycloak.Net.Interfaces;

namespace Keycloak.Net
{
    public class KeycloakClientFactory : IKeycloakClientFactory
    {
        public IKeycloakClient Create(string url, string userName, string password, KeycloakOptions options = null) => new KeycloakClient(url, userName, password, options);

        public IKeycloakClient Create(string url, string clientSecret, KeycloakOptions options = null) => new KeycloakClient(url, clientSecret, options);

        public IKeycloakClient Create(string url, Func<string> getToken, KeycloakOptions options = null) => new KeycloakClient(url, getToken, options);
    }
}
