using Confluent.Kafka;
using HealthChecks.UI.Client;
using Microservices.Demo.Payments.Service.Framework.DI;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Demo.Payments.Service.Framework.DI
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfigurationManager configuration)
        {
            services
                .AddHealthChecks()
                .AddNpgSql(configuration.GetConnectionString("PaymentsConnection"), name: "Payments-Service-PostgreSQL")
                //.AddNpgSql(configuration["BackgroundProcess:HangfireConnectionStringName"], name: "Payments-Job-PostgreSQL")
                .AddKafka(new ProducerConfig { BootstrapServers = configuration["Kafka:BootstrapServers"] }, "test-topic", "Payments-Service-Kafka");
                
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
