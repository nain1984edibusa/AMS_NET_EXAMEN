using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber
{
    public class GetPolicyAccountByNumberQuery:IQuery
    {
        public string PolicyNumber { get; set; }        
    }
}
