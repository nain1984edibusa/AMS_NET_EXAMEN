using Microservices.Demo.Gateway.Framework.Configuration;
using Microservices.Demo.Gateway.Framework.DI;
using Microservices.Demo.Gateway.Framework.Web;
using Microservices.Demo.Gateway.Infrastructure.Security;
using Microservices.Infrastructure.Trace;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Eureka;

namespace Microservices.Demo.Gateway.Framework
{
    public static class HostExtensions
    {
        public static IServiceCollection AddHostServices(this IServiceCollection services, IConfigurationManager configuration, IWebHostEnvironment environment, ILoggingBuilder logging)
        {            
            services.AddSecurity(configuration);
            services.AddOcelotConfiguration(configuration, environment);
            services.AddAllowAllCorsPolicy();
            services.AddHealthChecks(configuration);
            services.AddTelemetry();
            services.AddAllElasticApm();

            logging.AddConsole();

            return services;
        }
        public static async Task<WebApplication> UseHostSetupAsync(this WebApplication app)
        {

            app.UseAllowAllCorsPolicy();
            app.MapHealthChecks();
            await app.UseOcelot();            

            return app;
        }
    }
}
