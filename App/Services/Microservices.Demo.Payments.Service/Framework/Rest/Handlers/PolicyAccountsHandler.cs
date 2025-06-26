using AutoMapper;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Interfaces;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber;
using Microservices.Demo.Payments.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Payments.Service.Framework.Rest.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Demo.Payments.Service.Framework.Rest.Handlers
{
    public static class PolicyAccountsHandler
    {
        public static async Task<IResult> GetPolicyAccountByNumberAsync(
        [FromServices] IMapper _mapper,
        [FromServices] IPolicyAccountApplicationServices _service,
        [AsParameters] GetPolicyAccountByNumberRequest request)
        {
            var result = await _service.GetPolicyAccountByNumber.ExecuteAsync(_mapper.Map<GetPolicyAccountByNumberQuery>(request));
            return result is not null ? Results.Ok(_mapper.Map<GetPolicyAccountByNumberResponse>(result)) : Results.NotFound();
        }
    }
}
