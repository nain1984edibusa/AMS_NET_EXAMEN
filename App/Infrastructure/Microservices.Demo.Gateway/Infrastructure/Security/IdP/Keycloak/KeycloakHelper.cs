using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace Microservices.Demo.Gateway.Infrastructure.Security.IdP.Keycloak
{
    public class KeycloakHelper
    {
        private static ConfigurationManager<OpenIdConnectConfiguration> _configurationManager;

        public static async Task<OpenIdConnectConfiguration> GetConfigurationAsync(string authority, string realm)
        {
            if (_configurationManager == null)
            {
                var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                    $"{authority}/realms/{realm}/.well-known/openid-configuration",
                    new OpenIdConnectConfigurationRetriever(),
                    new HttpDocumentRetriever());

                var config = await configManager.GetConfigurationAsync();
                Interlocked.CompareExchange(ref _configurationManager, configManager, null);
            }

            return await _configurationManager.GetConfigurationAsync();
        }
        public static RSA GetRealmSigningKey(string serverIdP, string realm)
        {
            var realmPublicKey = GetRealmPublicKeyAsync(serverIdP, realm).Result;
            var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(Convert.FromBase64String(realmPublicKey), out _);
            return rsa;
        }

        private static async Task<string> GetRealmPublicKeyAsync(string serverIdP, string realm)
        {
            var url = $"{serverIdP}/realms/{realm}";

            try
            {
                var handler = new HttpClientHandler();

                using (var client = new HttpClient(handler))
                {
                    Console.WriteLine($"Getting public key from {url}");
                    var response = await client.GetAsync($"{serverIdP}/realms/{realm}");
                    response.EnsureSuccessStatusCode();
                    var content = await response.Content.ReadAsStringAsync();
                    var json = JObject.Parse(content);
                    var publicKey = json["public_key"].ToString();
                    return publicKey;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Error getting public key from: {url}");
                throw;
            }


        }
    }

}
