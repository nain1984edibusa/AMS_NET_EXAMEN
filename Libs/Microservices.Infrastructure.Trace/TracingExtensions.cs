using Confluent.Kafka.Extensions.OpenTelemetry;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using System.Diagnostics;
using System.Reflection;

namespace Microservices.Infrastructure.Trace
{
    public static class TracingExtensions
    {
        public static IServiceCollection AddTelemetry(this IServiceCollection services)
        {
            using var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();

            var otlpEndpoint = configuration["OtelCollector:Endpoint"];
            //var serviceName = Assembly.GetCallingAssembly().GetName().Name ?? "unknown-service";
            var serviceName = configuration["OtelCollector:ServiceName"] ?? Assembly.GetCallingAssembly().GetName().Name ?? "unknown-service";
                        
            var activitySource = new ActivitySource(serviceName);
            services.AddSingleton(activitySource);


            ActivityListener listener = new ActivityListener
            {
                ShouldListenTo = s => s.Name == serviceName,
                Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllDataAndRecorded,
                ActivityStarted = activity => { },
                ActivityStopped = activity => { }
            };

            ActivitySource.AddActivityListener(listener);

            services.AddOpenTelemetry()
                .WithTracing(b =>
                {
                    b
                    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService(serviceName))
                    .AddAspNetCoreInstrumentation()
                    .AddHttpClientInstrumentation()
                    .AddConfluentKafkaInstrumentation()
                    .AddSqlClientInstrumentation()
                    .AddNpgsql()
                    .AddEntityFrameworkCoreInstrumentation()
                    .AddElasticsearchClientInstrumentation()
                    .AddSource(serviceName)
                    .AddOtlpExporter(opt =>
                    {
                        opt.Endpoint = new Uri(otlpEndpoint);
                        opt.Protocol = OpenTelemetry.Exporter.OtlpExportProtocol.Grpc;
                    });
                });

            return services;
        }
    }
}
