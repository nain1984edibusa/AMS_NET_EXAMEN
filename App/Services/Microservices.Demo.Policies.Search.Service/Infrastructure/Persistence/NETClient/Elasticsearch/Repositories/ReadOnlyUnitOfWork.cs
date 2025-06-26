using Elastic.Clients.Elasticsearch;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Repositories;

namespace Microservices.Demo.Policies.Search.Service.Infrastructure.Persistence.NETClient.Elasticsearch.Repositories
{
    public class ReadOnlyUnitOfWork : ElasticGenericUnitOfWork<ElasticsearchClient>, IReadOnlyUnitOfWork
    {
        public IPolicyReadOnlyRepository Policies { get; }

        public ReadOnlyUnitOfWork(
            ElasticsearchClient client,
            IPolicyReadOnlyRepository policies
        ) : base(client)
        {
            Policies = policies;
        }
    }
}
