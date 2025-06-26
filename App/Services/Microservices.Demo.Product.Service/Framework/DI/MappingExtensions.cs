using Microservices.Demo.Products.Service.Application.UseCases.Product.Mappings;
using Microservices.Demo.Products.Service.Framework.Rest.Mappings;

namespace Microservices.Demo.Products.Service.Framework.DI
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {            
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
                
                cfg.AddProfile<RestProfile>();
            });

            return services;
        }
    }
}
