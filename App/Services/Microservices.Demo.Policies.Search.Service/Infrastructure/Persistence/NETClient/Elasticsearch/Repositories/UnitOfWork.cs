using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Analysis;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Repositories;

namespace Microservices.Demo.Policies.Search.Service.Infrastructure.Persistence.NETClient.Elasticsearch.Repositories
{
    public class UnitOfWork : ElasticGenericUnitOfWork<ElasticsearchClient>, IReadModelUnitOfWork
    {
        public IReadModelPolicyRepository Policies { get; }

        public UnitOfWork(
            ElasticsearchClient client,
            IReadModelPolicyRepository policies
        ) : base(client)
        {
            Policies = policies;
        }
        public override async Task EnsureCreatedAsync(CancellationToken cancellationToken = default)
        {
            var index = Policies.GetIndexName();
            var indexExistsResponse = await _client.Indices.ExistsAsync(index);
            if (indexExistsResponse.IsValidResponse && indexExistsResponse.Exists)
            {
                return; // Index already exists, no need to create it again.
            }
            var createIndexResponse = await _client.Indices.CreateAsync(index);                

            if (!createIndexResponse.IsValidResponse)
            {
                throw new Exception($"Failed to create index {index}: {createIndexResponse.ElasticsearchServerError?.Error?.Reason}");
            }
        }
    }
}
