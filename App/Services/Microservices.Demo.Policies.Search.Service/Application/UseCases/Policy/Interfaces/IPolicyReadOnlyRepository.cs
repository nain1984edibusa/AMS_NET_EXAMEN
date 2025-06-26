using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces
{
    public interface IPolicyReadOnlyRepository
    {
        Task<List<PolicyReadModel>> FindAsync(string queryText);
    }
}