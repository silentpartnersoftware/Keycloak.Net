using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Adapter;
using Xunit;

namespace Keycloak.Net.EmbraceTests
{
    public class EmbraceKeycloakClientShould
    {
        private readonly KeycloakClient _client;
        
        public EmbraceKeycloakClientShould()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            string baseUrl = configuration["baseUrl"];
            string prefix = configuration["prefix"] ?? "";
            string clientSecret = configuration["clientSecret"];

            if (string.IsNullOrWhiteSpace(baseUrl) || string.IsNullOrWhiteSpace(clientSecret))
            {
                throw new TestCanceledException("Keycloak base url and client secret must be provided to run the tests.");
            }
            
            _client = new KeycloakClient(baseUrl, clientSecret, new KeycloakOptions(prefix));
        }
        
        [Theory]
        [InlineData("embracecloud")]
        public async Task GetRealmLocalizationLocales(string realm)
        {
            var response = await _client.GetRealmLocalizationLocales(realm);
            Assert.True(response.IsSuccessful);

            var locales = response.Payload;
            Assert.NotNull(locales);
        }
        
        [Theory]
        [InlineData("embracecloud", "en")]
        public async Task GetRealmLocalizationTexts(string realm, string locale)
        {
            var response = await _client.GetRealmLocalizationTexts(realm, locale);
            Assert.True(response.IsSuccessful);

            var locales = response.Payload;
            Assert.NotNull(locales);
        }
        
        [Theory]
        [InlineData("embracecloud", "en", "key1")]
        public async Task GetRealmLocalizationText(string realm, string locale, string key)
        {
            var response = await _client.GetRealmLocalizationText(realm, locale, key);
            Assert.True(response.IsSuccessful);

            var locales = response.Payload;
            Assert.NotNull(locales);
        }
    }
}
