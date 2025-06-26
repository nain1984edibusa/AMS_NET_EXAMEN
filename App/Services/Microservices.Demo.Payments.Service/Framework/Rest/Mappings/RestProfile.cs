using AutoMapper;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber;
using Microservices.Demo.Payments.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Payments.Service.Framework.Rest.Models.Responses;

using PolicyAccountBalanceAppDto = Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Dtos.PolicyAccountBalanceDto;
using PolicyAccountBalanceRestDto=Microservices.Demo.Payments.Service.Framework.Rest.Models.Dtos.PolicyAccountBalanceDto;


namespace Microservices.Demo.Payments.Service.Framework.Rest.Mappings
{
    public class RestProfile:Profile
    {
        public RestProfile()
        {
            CreateMap<GetPolicyAccountByNumberRequest, GetPolicyAccountByNumberQuery>();
            CreateMap<GetPolicyAccountByNumberResult, GetPolicyAccountByNumberResponse>();

            CreateMap<PolicyAccountBalanceAppDto, PolicyAccountBalanceRestDto>();
        }
    }
}
