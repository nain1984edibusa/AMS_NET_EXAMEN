using Microservices.Demo.Payments.Service.Framework.Rest.Models.Dtos;

namespace Microservices.Demo.Payments.Service.Framework.Rest.Models.Responses
{
    public class GetPolicyAccountByNumberResponse
    {
        public PolicyAccountBalanceDto Balance { get; set; }
    }
}
