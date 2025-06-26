using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Text.Json;

namespace Microservices.Demo.Gateway.Infrastructure.Security.IdP.Keycloak
{
    public class KeycloakClaimsTransformer : IClaimsTransformation
    {
        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var identity = (ClaimsIdentity)principal.Identity;

            // Buscar el claim "realm_access"
            var realmAccessClaim = identity.FindFirst("realm_access");
            if (realmAccessClaim != null)
            {
                using var doc = JsonDocument.Parse(realmAccessClaim.Value);
                if (doc.RootElement.TryGetProperty("roles", out var roles))
                {
                    foreach (var role in roles.EnumerateArray())
                    {
                        identity.AddClaim(new Claim("role", role.GetString()));
                    }
                }
            }

            // Buscar el claim "resource_access"
            var resourceAccessClaim = identity.FindFirst("resource_access");
            if (resourceAccessClaim != null)
            {
                using var doc = JsonDocument.Parse(resourceAccessClaim.Value);
                if (doc.RootElement.TryGetProperty("account", out var account))
                {
                    if (account.TryGetProperty("roles", out var accountRoles))
                    {
                        foreach (var role in accountRoles.EnumerateArray())
                        {
                            identity.AddClaim(new Claim("role", role.GetString()));
                        }
                    }
                }
            }

            return Task.FromResult(principal);
        }
    }

}
