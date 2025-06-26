using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Interfaces;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Services;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.CreatePolicy;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.TerminatePolicy;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Interfaces;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetAllPolicies;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetHolder;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Queries.GetPolicyDetailsByNumber;
using Microservices.Demo.Policies.Service.Application.UseCases.Policy.Services;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Framework.DI
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueryUseCase<GetAllPoliciesQuery, GetAllPoliciesResult>, GetAllPoliciesUseCase>();

            services.AddScoped<ICommandUseCase<CreateOfferCommand, CreateOfferResult>, CreateOfferUseCase>();
            services.AddScoped<ICommandUseCase<CreateOfferByAgentCommand, CreateOfferByAgentResult>, CreateOfferByAgentUseCase>();

            services.AddScoped<IQueryUseCase<GetPolicyDetailsByNumberQuery, GetPolicyDetailsByNumberResult>, GetPolicyDetailsByNumberUseCase>();
            services.AddScoped<IQueryUseCase<GetHolderByPolicyIdQuery, GetHolderByPolicyIdResult>, GetHolderByPolicyIdUseCase>();


            services.AddScoped<ICommandUseCase<CreatePolicyCommand, CreatePolicyResult>, CreatePolicyUseCase>();
            services.AddScoped<ICommandUseCase<TerminatePolicyCommand, TerminatePolicyResult>, TerminatePolicyUseCase>();

            services.AddScoped<IPolicyApplicationService, PolicyApplicationService>();
            services.AddScoped<IOfferApplicationService, OfferApplicationService>();


            return services;
        }
    }
}
