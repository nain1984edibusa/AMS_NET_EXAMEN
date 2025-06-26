using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Services;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Queries.FindPolicy;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Services;
using Microservices.SharedKernel.Application.ReadModels.Interfaces;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Framework.DI
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueryUseCase<FindPolicyQuery, FindPolicyResult>, FindPolicyUseCase>();
            services.AddScoped<IPolicyApplicationServices, PolicyApplicationServices>();

            services.AddScoped<IEventProjection<PolicyCreatedEvent>, PolicyCreatedProjection>();
            services.AddScoped<IPolicyProjectionService, PolicyProjectionService>();

            return services;
        }
    }
}
