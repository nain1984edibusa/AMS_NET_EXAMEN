using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.CreatePolicy;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.TerminatePolicy;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetAllPolicies;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetHolder;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetPolicyDetailsByNumber;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Handlers
{
    public static class PoliciesHandlers
    {
        public static async Task<IResult> GetAllPoliciesAsync(
           [FromServices] IPolicyApplicationService _service,
           [AsParameters] GetAllPoliciesRequest request
        )
        {
            var query = new GetAllPoliciesQuery
            {
                Page = request.Page,
                PageSize = request.PageSize
            };

            var result = await _service.GetAllPolicies.ExecuteAsync(query);

            var response = new GetAllPoliciesResponse
            {
                Policies = result.Policies
            };

            return Results.Ok(response);
        }

        public static async Task<IResult> GetPolicyDetailsByNumberAsync(
           [FromServices] IMapper _mapper,
           [FromServices] IPolicyApplicationService _service,
           [AsParameters] GetPolicyDetailsByNumberRequest request
        )
        {
            var command = _mapper.Map<GetPolicyDetailsByNumberQuery>(request);
            var result = await _service.GetPolicyDetailsByNumber.ExecuteAsync(command);

            return result is not null ? Results.Ok(_mapper.Map<GetPolicyDetailsByNumberResponse>(result)) : Results.NotFound();
        }

        public static async Task<IResult> GetHolderByPolicyIdAsync(
          [FromServices] IMapper _mapper,
          [FromServices] IPolicyApplicationService _service,
          [AsParameters] GetHolderByPolicyIdRequest request
       )
        {
            var result = await _service.GetHolderByPolicyId.ExecuteAsync(_mapper.Map<GetHolderByPolicyIdQuery>(request));
            return result is not null ? Results.Ok(_mapper.Map<GetHolderByPolicyIdResponse>(result)) : Results.NotFound();
        }

        public static async Task<IResult> CreatePolicyAsync(
            [FromServices] IMapper _mapper,
            [FromServices] IPolicyApplicationService _service,
            [FromBody] CreatePolicyRequest request
        )
        {
            var command = _mapper.Map<CreatePolicyCommand>(request);
            var result = await _service.CreatePolicy.ExecuteAsync(command);

            return Results.Created($"/api/products/{result.Number}", _mapper.Map<CreatePolicyResponse>(result));
        }
        public static async Task<IResult> TerminatePolicyAsync(
           [FromServices] IMapper _mapper,
           [FromServices] IPolicyApplicationService _service,
           [FromBody] TerminatePolicyRequest request
       )
        {
            var command = _mapper.Map<TerminatePolicyCommand>(request);
            var result = await _service.TerminatePolicy.ExecuteAsync(command);

            return result is not null ? Results.Ok(_mapper.Map<TerminatePolicyResponse>(result)) : Results.NotFound();
        }
    }
}
