using AutoMapper;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Dtos;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Mappings
{
    public class PolicyProfile : Profile
    {
        public PolicyProfile()
        {
            CreateMap<PolicyReadModel, PolicyDto>();
            CreateMap<List<PolicyReadModel>, FindPolicyResult>()
               .ForMember(dest => dest.Policies, opt => opt.MapFrom(src => src));
        }
    }
}
