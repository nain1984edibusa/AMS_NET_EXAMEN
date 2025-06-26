using Microservices.Demo.Products.Service.Framework.Data;
using Microservices.Demo.Products.Service.Framework.DI;
using Microservices.Demo.Products.Service.Framework.Web;
using Microservices.Infrastructure.Trace;
using Microsoft.Extensions.Configuration;
using Scalar.AspNetCore;
using Steeltoe.Discovery.Client;
using Steeltoe.Discovery.Eureka;

namespace Microservices.Demo.Products.Service.Framework
{
    public static class HostExtensions
    {
        public static IServiceCollection AddHostServices(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddTelemetry();
            services.AddDiscoveryClient(configuration);
            services.AddApplication();
            services.AddPersistence(configuration);
            services.AddMappings();
            services.AddHealthChecks(configuration);
            services.AddAllElasticApm();

            services.AddOpenApi();

            return services;
        }
        public static async Task<WebApplication> UseHostSetupAsync(this WebApplication app)
        {
            app.UseExceptionHandler("/errors");
            app.MapOpenApi();
            app.MapScalarApiReference(options => { options.Servers = Array.Empty<ScalarServer>(); });
            app.MapAllEndpoints();
            await app.SeedDatabaseAsync();
            app.MapHealthChecks();

            return app;
        }
    }
}
