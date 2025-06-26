using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;
using Microservices.Infrastructure.Persistences.NETClient.Elasticsearch.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces
{
    public interface IReadModelPolicyRepository : IElasticReadModelRepository<PolicyReadModel>
    {        
    }
}
