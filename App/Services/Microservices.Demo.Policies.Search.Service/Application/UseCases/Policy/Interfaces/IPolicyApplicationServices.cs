using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces
{
    public interface IPolicyApplicationServices
    {
        IQueryUseCase<FindPolicyQuery, FindPolicyResult> FindPolicy { get; }
    }
}