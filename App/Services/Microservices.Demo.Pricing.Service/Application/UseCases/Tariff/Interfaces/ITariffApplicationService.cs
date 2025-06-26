using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Interfaces
{
    public interface ITariffApplicationService
    {
        ICommandUseCase<CalculatePriceCommand, CalculatePriceResult> CalculatePrice { get; }
    }
}