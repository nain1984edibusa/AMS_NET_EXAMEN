using AutoMapper;
using MediatR;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Mappings
{
    public class ReadModelPolicyProfile: Profile
    {
        public ReadModelPolicyProfile()
        {
            CreateMap<PolicyCreatedEvent, PolicyReadModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PolicyNumber))
                .ForMember(dest => dest.PolicyNumber, opt => opt.MapFrom(src => src.PolicyNumber))
                .ForMember(dest => dest.PolicyStartDate, opt => opt.MapFrom(src => src.PolicyFrom))
                .ForMember(dest => dest.PolicyEndDate, opt => opt.MapFrom(src => src.PolicyTo))
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.ProductCode))
                .ForMember(dest => dest.PolicyHolder, opt => opt.MapFrom(src => $"{src.PolicyHolder.FirstName} {src.PolicyHolder.LastName}"))
                .ForMember(dest => dest.PremiumAmount, opt => opt.MapFrom(src => src.TotalPremium));
        }
    }
}
