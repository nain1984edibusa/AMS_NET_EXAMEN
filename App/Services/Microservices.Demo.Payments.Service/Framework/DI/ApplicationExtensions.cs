using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.ClosePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.CreatePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.RegisterInPayments;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Interfaces;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Services;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Framework.DI
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {             
            services.AddScoped<ICommandUseCase<CreatePolicyAccountCommand>, CreatePolicyAccountUseCase>();
            services.AddScoped<ICommandUseCase<ClosePolicyAccountCommand>, ClosePolicyAccountUseCase>();
            services.AddScoped<ICommandUseCase<RegisterInPaymentsCommand>, RegisterInPaymentsUseCase>();
            services.AddScoped<IQueryUseCase<GetPolicyAccountByNumberQuery, GetPolicyAccountByNumberResult>, GetPolicyAccountByNumberUseCase>();

            services.AddScoped<IPolicyAccountApplicationServices, PolicyAccountApplicationServices>();

            return services;
        }
    }
}
