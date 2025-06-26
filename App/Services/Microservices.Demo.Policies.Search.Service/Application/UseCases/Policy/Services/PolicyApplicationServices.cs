using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Services
{
    public class PolicyApplicationServices : IPolicyApplicationServices
    {
        public IQueryUseCase<FindPolicyQuery, FindPolicyResult> FindPolicy { get; }
        public PolicyApplicationServices(
            IQueryUseCase<FindPolicyQuery, FindPolicyResult> findPolicy
        )
        {
            FindPolicy = findPolicy ?? throw new ArgumentNullException(nameof(findPolicy));
        }
    }
}
