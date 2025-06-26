namespace Microservices.Demo.Gateway.Infrastructure.Security.IdP.Keycloak
{
    public class keycloakSettings
    {
        public string Server { get; set; } = string.Empty;
        public string Realm { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Authority { get; set; } = string.Empty;
    }
}
