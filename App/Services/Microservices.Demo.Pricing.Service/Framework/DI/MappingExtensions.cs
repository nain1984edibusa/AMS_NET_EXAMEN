using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Mappings;
using Microservices.Demo.Pricing.Service.Framework.Rest.Mappings;

namespace Microservices.Demo.Pricing.Service.Framework.DI
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TariffProfile>();

                cfg.AddProfile<RestProfile>();
            });

            return services;
        }
    }
}
