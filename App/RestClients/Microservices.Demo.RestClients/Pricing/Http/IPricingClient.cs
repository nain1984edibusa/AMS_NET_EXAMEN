using Microservices.Demo.RestClients.Pricing.Models.Requests;
using Microservices.Demo.RestClients.Pricing.Models.Response;
using RestEase;

namespace Microservices.Demo.RestClients.Pricing.Http
{
    public interface IPricingClient
    {
        [Post("calculate-price")]
        Task<CalculatePriceResponse> CalculatePrice([Body] CalculatePriceRequest req);
    }
}
