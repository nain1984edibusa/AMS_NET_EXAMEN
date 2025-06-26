using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Demo.Policies.Search.Service.Infrastructure.Persistence.NETClient.Elasticsearch.ElasticClients
{
    public class ElasticClientOptions
    {
        public string[] Hosts { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }

    }

    public static class ElasticClientExtensions
    {
        public static IServiceCollection AddElasticsearch(this IServiceCollection services, Action<ElasticClientOptions> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            var options = new ElasticClientOptions();
            configure(options);

            if (options.Hosts == null || options.Hosts.Length == 0)
                throw new InvalidOperationException("No ElasticSearch hosts configured!");

            var uris = options.Hosts.Select(h => new Uri(h)).ToArray();
            var pool = new StaticNodePool(uris);

            var settings = new ElasticsearchClientSettings(pool)
                    .EnableDebugMode()
                    .DisableDirectStreaming();
                        
            if (!string.IsNullOrEmpty(options.Username) && !string.IsNullOrEmpty(options.Password))
                settings = settings.Authentication(new BasicAuthentication(options.Username, options.Password));

            var elasticClient = new ElasticsearchClient(settings);

            var info = elasticClient.Info();
            if (!info.IsValidResponse)
            {
                throw new InvalidOperationException("Don't connect to ElasticSearch! " + $"Error: {info.ElasticsearchServerError?.Error?.Reason}");
            }

            services.AddSingleton(elasticClient);

            return services;
        }
    }
}
