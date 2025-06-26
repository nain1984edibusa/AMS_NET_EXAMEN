using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice
{
    public class CalculatePriceResult:ICommandResult
    {
        public decimal TotalPrice { get; set; }
        public Dictionary<string, decimal> CoverPrices { get; set; }

        public static CalculatePriceResult Empty()
        {
            return new CalculatePriceResult { TotalPrice = 0M, CoverPrices = new Dictionary<string, decimal>() };
        }
    }
}
