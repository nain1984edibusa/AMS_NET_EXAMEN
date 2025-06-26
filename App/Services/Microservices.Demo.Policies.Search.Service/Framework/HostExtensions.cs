using Microservices.Demo.Policies.Search.Service.Framework.Data;
using Microservices.Demo.Policies.Search.Service.Framework.DI;
using Microservices.Demo.Policies.Search.Service.Framework.Web;
using Microservices.Demo.Policies.Service.Framework.DI;
using Microservices.Infrastructure.Trace;
using Scalar.AspNetCore;
using Steeltoe.Discovery.Client;

namespace Microservices.Demo.Policies.Search.Service.Framework
{
    public static class HostExtensions
    {
        public static IServiceCollection AddHostServices(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddDiscoveryClient(configuration);
            services.AddApplication();
            services.AddPersistence(configuration);
            services.AddMappings();
            services.AddMessaging(configuration);
            services.AddHealthChecks(configuration);
            services.AddTelemetry();
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
