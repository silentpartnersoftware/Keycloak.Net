using System;

namespace Keycloak.Net.Interfaces
{
    public interface IKeycloakClientFactory
    {
        IKeycloakClient Create(string url, string userName, string password, KeycloakOptions options = null);
        IKeycloakClient Create(string url, string clientSecret, KeycloakOptions options = null);
        IKeycloakClient Create(string url, Func<string> getToken, KeycloakOptions options = null);
    }
}