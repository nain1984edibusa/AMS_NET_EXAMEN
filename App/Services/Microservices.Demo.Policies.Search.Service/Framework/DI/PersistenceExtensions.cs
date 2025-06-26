using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Demo.Policies.Search.Service.Infrastructure.Persistence.NETClient.Elasticsearch.ElasticClients;
using Microservices.Demo.Policies.Search.Service.Infrastructure.Persistence.NETClient.Elasticsearch.Repositories;

namespace Microservices.Demo.Policies.Search.Service.Framework.DI
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager config)
        {
            services.AddElasticsearch(options =>
            {
                options.Hosts = config.GetSection("Elasticsearch:Hosts").Get<string[]>();
                options.Username = config["Elasticsearch:Username"];
                options.Password = config["Elasticsearch:Password"];
            });

            services.AddScoped<IReadModelPolicyRepository, PolicyRepository>();
            services.AddScoped<IReadModelUnitOfWork, UnitOfWork>();

            services.AddScoped<IPolicyReadOnlyRepository, PolicyReadOnlyRepository>();
            services.AddScoped<IReadOnlyUnitOfWork, ReadOnlyUnitOfWork>();

            return services;
        }
    }
}
