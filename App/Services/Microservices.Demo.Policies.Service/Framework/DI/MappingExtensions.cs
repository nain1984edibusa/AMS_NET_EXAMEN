using AutoMapper;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Mappings;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Mappings;
using Microservices.Demo.Policies.Service.Framework.Agents.Mapings;
using Microservices.Demo.Products.Service.Framework.Rest.Mappings;

namespace Microservices.Demo.Products.Service.Framework.DI
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<OfferProfile>();                
                cfg.AddProfile<PolicyProfile>();

                cfg.AddProfile<OfferRestProfile>();
                cfg.AddProfile<PolicyRestProfile>();

                cfg.AddProfile<PricingAgentProfile>();               
            });

            return services;
        }
    }
}
