using HealthChecks.UI.Client;
using Microservices.Demo.Gateway.Framework.DI;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Demo.Gateway.Framework.DI
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfigurationManager configuration)
        {
            services
                .AddHealthChecks();                
            
            //services.AddAllActuators();

            return services;
        }
        public static WebApplication MapHealthChecks(this WebApplication app)
        {
            app.UseRouting();            
            //app.UseEndpoints(endpoints => { endpoints.MapAllActuators(); });            
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
