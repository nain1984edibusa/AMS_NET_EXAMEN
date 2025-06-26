using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;
using Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Interfaces
{
    public interface IPricingAgent
    {
        Task<Price> CalculatePrice(CalculatePriceParamsDto pricingParams);
    }
}
