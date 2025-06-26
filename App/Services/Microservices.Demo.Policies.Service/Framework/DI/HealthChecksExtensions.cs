using Confluent.Kafka;
using HealthChecks.UI.Client;
using Microservices.Demo.Policies.Service.Framework.DI;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.DependencyInjection;

namespace Microservices.Demo.Policies.Service.Framework.DI
{
    public static class HealthChecksExtensions
    {
        public static IServiceCollection AddHealthChecks(this IServiceCollection services, IConfigurationManager configuration)
        {
            services
                .AddHealthChecks()
                .AddMySql(configuration.GetConnectionString("PoliciesConnection"), name: "Policies-Service-MySQL")
                //.AddSqlServer(configuration["Kafka:Persistence:Outbox:MessagingConnection"], name: "Policies-Service-SQLServer")
                .AddUrlGroup(new Uri("http://pricing.service:8080/scalar/v1"),name: "Policies-Service-Pricing-Url")
                .AddKafka(new ProducerConfig { BootstrapServers = configuration["Kafka:BootstrapServers"] }, "test-topic", "Policies-Service-Kafka");
                
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
