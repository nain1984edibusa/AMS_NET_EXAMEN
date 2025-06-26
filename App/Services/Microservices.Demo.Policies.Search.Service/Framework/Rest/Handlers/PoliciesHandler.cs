using AutoMapper;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy;
using Microservices.Demo.Policies.Search.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Policies.Search.Service.Framework.Rest.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Demo.Policies.Search.Service.Framework.Rest.Handlers
{
    public static class PoliciesHandler
    {
        public static async Task<IResult> FindPolicyAsync(
          [FromServices] IMapper _mapper,
          [FromServices] IPolicyApplicationServices _service,
          [AsParameters] FindPolicyRequest request
       )
        {
            var query = _mapper.Map<FindPolicyQuery>(request);
            var result = await _service.FindPolicy.ExecuteAsync(query);

            return result is not null ? Results.Ok(_mapper.Map<FindPolicyResponse>(result)) : Results.NotFound();
        }
    }
}
