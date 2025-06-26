using Confluent.Kafka;
using HealthChecks.UI.Client;
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
                .AddElasticsearch(setup =>
                {
                    setup.UseServer(configuration["ElasticSearch:Hosts:0"]);
                    setup.UseBasicAuthentication(configuration["ElasticSearch:Username"], configuration["ElasticSearch:Password"]);
                })
                .AddKafka(new ProducerConfig { BootstrapServers = configuration["Kafka:BootstrapServers"] }, "test-topic", "Policies-Search-Service-Kafka");
                
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
