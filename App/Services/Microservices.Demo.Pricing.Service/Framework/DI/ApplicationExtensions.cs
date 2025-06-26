using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Interfaces;
using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Services;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Pricing.Service.Framework.DI
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICommandUseCase<CalculatePriceCommand, CalculatePriceResult>, CalculatePriceUseCase>();

            services.AddScoped<ITariffApplicationService, TariffApplicationService>();


            return services;
        }
    }
}
