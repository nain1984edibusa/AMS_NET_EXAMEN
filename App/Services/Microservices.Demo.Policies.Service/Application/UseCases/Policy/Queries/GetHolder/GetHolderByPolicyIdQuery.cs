using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetHolder
{
    public class GetHolderByPolicyIdQuery : IQuery
    {
        public string PolicyId { get; set; }
    }
}
