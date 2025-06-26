using Microservices.Demo.Gateway.Infrastructure.Security;
using Microservices.Demo.Gateway.Infrastructure.Security.IdP.Keycloak;
using Microservices.Demo.Gateway.Infrastructure.Security.Ocelot;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.Authorization;

namespace Microservices.Demo.Gateway.Infrastructure.Security
{
    public static class SecurityExtensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddTransient<IClaimsTransformation, KeycloakClaimsTransformer>();
            services.AddSingleton<IClaimsAuthorizer, CustomClaimsAuthorizer>();

            services.AddAuthentication(configuration);

            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var idpSettingsSection = configuration.GetSection("Keycloak");
            var idpSettings = idpSettingsSection.Get<keycloakSettings>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer("ApiSecurityAuthenticationScheme", options =>
            {
                options.Authority = idpSettings.Authority;
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidIssuer = idpSettings.Issuer,
                    RequireExpirationTime = true,
                    ClockSkew = TimeSpan.Zero,
                    IssuerSigningKey = new RsaSecurityKey(KeycloakHelper.GetRealmSigningKey(idpSettings.Server, idpSettings.Realm))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = ctx =>
                    {
                        Console.WriteLine($"[AUTH ERROR] {ctx.Exception}");
                        return Task.CompletedTask;
                    }
                };

            });

            return services;
        }
    }

}
