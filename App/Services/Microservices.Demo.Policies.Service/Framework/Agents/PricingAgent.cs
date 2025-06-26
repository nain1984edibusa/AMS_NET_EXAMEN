using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Interfaces;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;
using Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;
using Microservices.Demo.RestClients.Pricing.Http;
using Microservices.Demo.RestClients.Pricing.Models.Requests;

namespace Microservices.Demo.Policies.Service.Framework.Agents
{
    public class PricingAgent : IPricingAgent
    {
        private readonly IPricingClient _pricingClient;
        private readonly IMapper _mapper;

        public PricingAgent(
            IPricingClient pricingClient,
            IMapper mapper
        )
        {
            _pricingClient = pricingClient;
            _mapper = mapper;
        }

        public async Task<Price> CalculatePrice(CalculatePriceParamsDto pricingParams)
        {
            var req = _mapper.Map<CalculatePriceRequest>(pricingParams);
            var result = await _pricingClient.CalculatePrice(req);

            return new Price(result.CoverPrices);
        }
    }
}
