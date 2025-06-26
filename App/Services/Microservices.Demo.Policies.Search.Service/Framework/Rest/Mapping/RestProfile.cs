
using AutoMapper;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Dtos;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy;
using Microservices.Demo.Policies.Search.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Policies.Search.Service.Framework.Rest.Models.Responses;

namespace Microservices.Demo.Policies.Search.Service.Framework.Rest.Mapping
{
    public class RestProfile:Profile
    {
        public RestProfile()
        {
            CreateMap<FindPolicyRequest, FindPolicyQuery>();
            CreateMap<PolicyDto, PolicyResponse>();
            CreateMap<FindPolicyResult, FindPolicyResponse>();
        }
    }
}
