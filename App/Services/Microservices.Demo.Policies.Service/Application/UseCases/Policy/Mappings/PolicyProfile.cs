using AutoMapper;
using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.CreatePolicy;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetAllPolicies;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetHolder;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetPolicyDetailsByNumber;
using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.Demo.Policies.Service.Domain.Policies.Extensions;
using Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests;
using PersonMsgDto=Microservices.Demo.Messages.Services.Policies.Dtos.PersonDto;
using PolicyEntity=Microservices.Demo.Policies.Service.Domain.Policies.Entities.Policy;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Mappings
{
    public class PolicyProfile : Profile
    {
        public PolicyProfile()
        {
            CreateMap<PolicyEntity, PolicyDto>()        
                .ForMember(dest => dest.DateFrom, opt => opt.MapFrom(src => src.Versions.FirstVersion().CoverPeriod.ValidFrom))
                .ForMember(dest => dest.DateTo, opt => opt.MapFrom(src => src.Versions.FirstVersion().CoverPeriod.ValidTo))
                .ForMember(dest => dest.PolicyHolder, opt => opt.MapFrom(src => $"{src.Versions.FirstVersion().PolicyHolder.FirstName} {src.Versions.FirstVersion().PolicyHolder.LastName}"))
                .ForMember(dest => dest.TotalPremium, opt => opt.MapFrom(src => src.Versions.FirstVersion().TotalPremiumAmount))
                .ForMember(dest => dest.AccountNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Covers, opt => opt.MapFrom(src => src.Versions.FirstVersion().Covers.Select(c => c.Code).ToList()));

            CreateMap<PolicyEntity, PolicyCreatedEvent>()
               .ForMember(dest => dest.PolicyNumber, opt => opt.MapFrom(src => src.Number))
               .ForMember(dest => dest.PolicyFrom, opt => opt.MapFrom(src => src.Versions.First(v => v.VersionNumber == 1).CoverPeriod.ValidFrom))
               .ForMember(dest => dest.PolicyTo, opt => opt.MapFrom(src => src.Versions.First(v => v.VersionNumber == 1).CoverPeriod.ValidTo))
               .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.ProductCode))
               .ForMember(dest => dest.TotalPremium, opt => opt.MapFrom(src => src.Versions.First(v => v.VersionNumber == 1).TotalPremiumAmount))
               .ForMember(dest => dest.PolicyHolder, opt => opt.MapFrom(src => new PersonMsgDto
               {
                   FirstName = src.Versions.First(v => v.VersionNumber == 1).PolicyHolder.FirstName,
                   LastName = src.Versions.First(v => v.VersionNumber == 1).PolicyHolder.LastName,
                   TaxId = src.Versions.First(v => v.VersionNumber == 1).PolicyHolder.Pesel
               }))
               .ForMember(dest => dest.AgentLogin, opt => opt.MapFrom(src => src.AgentLogin));

            CreateMap<PolicyTerminationResult, PolicyTerminatedEvent>()
               .ForMember(dest => dest.PolicyNumber, opt => opt.MapFrom(src => src.TerminalVersion.Policy.Number))
               .ForMember(dest => dest.PolicyFrom, opt => opt.MapFrom(src => src.TerminalVersion.CoverPeriod.ValidFrom))
               .ForMember(dest => dest.PolicyTo, opt => opt.MapFrom(src => src.TerminalVersion.CoverPeriod.ValidTo))
               .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.TerminalVersion.Policy.ProductCode))
               .ForMember(dest => dest.TotalPremium, opt => opt.MapFrom(src => src.TerminalVersion.TotalPremiumAmount))
               .ForMember(dest => dest.AmountToReturn, opt => opt.MapFrom(src => src.AmountToReturn))
               .ForMember(dest => dest.PolicyHolder, opt => opt.MapFrom(src => new PersonMsgDto
               {
                   FirstName = src.TerminalVersion.PolicyHolder.FirstName,
                   LastName = src.TerminalVersion.PolicyHolder.LastName,
                   TaxId = src.TerminalVersion.PolicyHolder.Pesel
               }));

            CreateMap<PolicyEntity, CreatePolicyResult>().IncludeBase<PolicyEntity, PolicyDto>();
            CreateMap<PolicyEntity, GetPolicyDetailsByNumberResult>().IncludeBase<PolicyEntity, PolicyDto>();

            CreateMap<List<PolicyEntity>, GetAllPoliciesResult>()
              .ForMember(dest => dest.Policies, opt => opt.MapFrom(src => src));


            CreateMap<GetAllPoliciesRequest, GetAllPoliciesQuery>();
            // Mapeo base entre la entidad y el DTO
            CreateMap<PolicyVersion, PolicyVersionDto>();

            CreateMap<PolicyVersion, GetHolderByPolicyIdResult>()
            .IncludeBase<PolicyVersion, PolicyVersionDto>();
        }
    }
}
