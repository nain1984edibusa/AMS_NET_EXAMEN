using Microservices.Demo.RestClients.Pricing.Http;
using Microservices.Infrastructure.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Demo.RestClients.Pricing
{
    public static class PricingRestClientExtensions
    {
        public static IServiceCollection AddPricingRestClient(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddDiscoveryClient(configuration);
            services.AddUrlServices(configuration);
            services.AddScoped<IPricingClient, PricingClient>();

            services.AddSingleton<IPricingClient>(provider =>
            {
                var config = provider.GetRequiredService<IConfiguration>();
                var discovery = provider.GetRequiredService<IDiscoveryClient>();
                var urlService = provider.GetRequiredService<IUrlService>();
                return new PricingClient(config, discovery, urlService);
            });

            return services;
        }
    }
}
