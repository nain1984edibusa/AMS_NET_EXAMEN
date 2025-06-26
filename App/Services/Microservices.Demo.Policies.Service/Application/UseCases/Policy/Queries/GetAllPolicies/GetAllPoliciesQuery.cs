using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetAllPolicies
{
    public class GetAllPoliciesQuery : IQuery
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }
}
