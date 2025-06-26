using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Http
{
    public static class UrlServiceExtensions
    {
        public static IServiceCollection AddUrlServices(this IServiceCollection services, IConfigurationManager configuration)
        {            
            var urlDict = configuration.GetSection("URLServices")
                .GetChildren()
                .ToDictionary(x => x.Key, x => x.Value);

            services.AddSingleton<IOptions<Dictionary<string, string>>>(
                new OptionsWrapper<Dictionary<string, string>>(urlDict)
            );
            services.AddSingleton<IUrlService, UrlService>();

            return services;
        }
    }
}
