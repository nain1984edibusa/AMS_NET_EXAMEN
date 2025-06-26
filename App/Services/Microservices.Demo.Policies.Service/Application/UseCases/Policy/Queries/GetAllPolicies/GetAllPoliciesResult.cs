using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetAllPolicies
{
    public class GetAllPoliciesResult : IQueryResult
    {
        public List<PolicyDto> Policies { get; set; }
    }
}
