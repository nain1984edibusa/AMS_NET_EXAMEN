using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy
{
    public class FindPolicyResult:IQueryResult
    {
        public List<PolicyDto> Policies { get; set; }
    }
}
