using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Interfaces;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests;
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Handlers
{
    public static class OffersHandlers
    {
        public static async Task<IResult> CreateOfferAsync(
           [FromServices] IMapper _mapper,
           [FromServices] IOfferApplicationService _service,
           [FromHeader] string? agentLogin,
           [FromBody] CreateOfferRequest request
        )
        {
            var command = _mapper.Map<CreateOfferCommand>(request);

            var hasAgentLogin = !IsNullOrWhiteSpace(agentLogin);

            if (!hasAgentLogin)
            {
                var result = await _service.CreateOffer.ExecuteAsync(command);
                return Results.Ok(_mapper.Map<CreateOfferResponse>(result));
            }
            else
            {
                var result = await _service.CreateOfferByAgent.ExecuteAsync(new CreateOfferByAgentCommand(agentLogin, command));
                return Results.Ok(_mapper.Map<CreateOfferByAgentResponse>(result));
            }                
        }
    }
}
