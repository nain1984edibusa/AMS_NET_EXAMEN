using Microservices.Demo.Policies.Service.Application.UseCases.Interfaces;
using Microservices.Demo.Policies.Service.Framework.Agents;
using Microservices.Demo.RestClients.Pricing;

namespace Microservices.Demo.Policies.Service.Framework.DI
{
    public static class RestClientsExtensions
    {
        public static IServiceCollection AddRestClients(this IServiceCollection services,IConfigurationManager configuration)
        {
            services.AddPricingRestClient(configuration);
            services.AddScoped<IPricingAgent, PricingAgent>();

            return services;
        }
    }
}
