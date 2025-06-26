using AutoMapper;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber;
using PolicyAccountEntity = Microservices.Demo.Payments.Service.Domain.Payments.Entities.PolicyAccount;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Mappings
{
    public class PolicyAccounProfile:Profile
    {
        public PolicyAccounProfile()
        {
            CreateMap<PolicyAccountEntity, GetPolicyAccountByNumberResult>()
            .ForPath(dest => dest.Balance.PolicyNumber, opt => opt.MapFrom(src => src.PolicyNumber))
            .ForPath(dest => dest.Balance.PolicyAccountNumber, opt => opt.MapFrom(src => src.PolicyAccountNumber))
            .ForPath(dest => dest.Balance.Balance, opt => opt.MapFrom(src => src.BalanceAt(DateTimeOffset.Now)));
        }
    }
}
