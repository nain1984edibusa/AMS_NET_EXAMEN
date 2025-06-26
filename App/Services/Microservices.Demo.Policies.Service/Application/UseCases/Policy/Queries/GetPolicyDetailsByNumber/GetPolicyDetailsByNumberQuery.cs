using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetPolicyDetailsByNumber
{
    public class GetPolicyDetailsByNumberQuery: IQuery
    {   public string PolicyNumber { get; set; }
    }
}
