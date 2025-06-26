using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy
{
    public class FindPolicyQuery : IQuery
    {
        public string QueryText { get; set; }
    }
}
