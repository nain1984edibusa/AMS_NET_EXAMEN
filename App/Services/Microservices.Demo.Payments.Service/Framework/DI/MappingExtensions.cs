using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Mappings;
using Microservices.Demo.Payments.Service.Framework.Messaging.Mappings;
using Microservices.Demo.Payments.Service.Framework.Rest.Mappings;

namespace Microservices.Demo.Payments.Service.Framework.DI
{
    public static class MappingExtensions
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<PolicyAccounProfile>();

                cfg.AddProfile<MessagingPolicyAccountProfile>();

                cfg.AddProfile<RestProfile>();
            });

            return services;
        }
    }
}
