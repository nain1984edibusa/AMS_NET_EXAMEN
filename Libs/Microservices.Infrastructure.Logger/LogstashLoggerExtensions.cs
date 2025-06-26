using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Json;

namespace Microservices.Infrastructure.Logger
{
    public static class LogstashLoggerExtensions
    {
        public static IHostBuilder AddSerilogLogstash(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, services, configuration) =>
            {
                var config = context.Configuration;

                configuration
                    .Enrich.WithProperty("Service", config["Logstash:ServiceName"])
                    .Enrich.WithProperty("Environment", config["Logstash:Environment"])
                    .Enrich.FromLogContext()
                    .WriteTo.DurableHttpUsingFileSizeRolledBuffers(
                        requestUri: config["Logstash:Uri"],
                        logEventsInBatchLimit: 100,
                        bufferBaseFileName: "./logs/logstash-buffer",
                        textFormatter: new JsonFormatter()
                    );
            });

            return hostBuilder;
        }
    }
}
