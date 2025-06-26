using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber
{
    public class GetPolicyAccountByNumberResult: IQueryResult
    {
        public PolicyAccountBalanceDto Balance { get; set; }
        public GetPolicyAccountByNumberResult()
        {
            Balance = new PolicyAccountBalanceDto();
        }
    }
}
