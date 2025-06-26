using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;
using Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Repositories;

namespace Microservices.Demo.Policies.Search.Service.Infrastructure.Persistence.NETClient.Elasticsearch.Repositories
{
    public class PolicyRepository : ElasticRepository<PolicyReadModel, ElasticsearchClient>, IReadModelPolicyRepository
    {
        public PolicyRepository(ElasticsearchClient context) : base(context) { }
    }
}
