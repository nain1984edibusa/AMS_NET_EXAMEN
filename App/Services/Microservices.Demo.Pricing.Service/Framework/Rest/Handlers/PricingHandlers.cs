using AutoMapper;
using ImTools;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Interfaces;
using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Request;
using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Handlers
{
    public static class PricingHandlers
    {
        public static async Task<IResult> CalculatePriceAsync(
               [FromServices] IMapper _mapper,
               [FromServices] ITariffApplicationService _service,
               [FromBody] CalculatePriceRequest request
           )
        {
            var command = _mapper.Map<CalculatePriceCommand>(request);
            var result = await _service.CalculatePrice.ExecuteAsync(command);

            return Results.Ok(_mapper.Map<CalculatePriceResponse>(result));
        }
    }
}
