using HealthChecks.UI.Client;
using Microservices.Demo.Pricing.Service.Framework.DI;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Demo.Pricing.Service.Framework.DI
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfigurationManager configuration)
        {
            services
                .AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("PricingConnection"), name: "Pricing-Service-PostgreSQL");
            
            return services;
        }
        public static WebApplication MapHealthChecks(this WebApplication app)
        {
            app.UseRouting();
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksPrometheusExporter("/healthmetrics");

            return app;
        }
    }
}
