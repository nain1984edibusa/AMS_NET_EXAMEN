using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Interfaces;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Services
{
    public class TariffApplicationService : ITariffApplicationService
    {
        public ICommandUseCase<CalculatePriceCommand, CalculatePriceResult> CalculatePrice { get; }
        public TariffApplicationService(
            ICommandUseCase<CalculatePriceCommand, CalculatePriceResult> calculatePrice
        )
        {
            CalculatePrice = calculatePrice;
        }

    }
}
