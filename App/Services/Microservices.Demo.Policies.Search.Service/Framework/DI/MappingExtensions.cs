using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Mappings;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Mappings;
using Microservices.Demo.Policies.Search.Service.Framework.Messaging.Mappings;
using Microservices.Demo.Policies.Search.Service.Framework.Rest.Mapping;

namespace Microservices.Demo.Policies.Search.Service.Framework.DI
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<ReadModelPolicyProfile>();

                cfg.AddProfile<PolicyProfile>();

                cfg.AddProfile<MessagingPolicyProfile>();

                cfg.AddProfile<RestProfile>();
            });

            return services;
        }
    }
}
