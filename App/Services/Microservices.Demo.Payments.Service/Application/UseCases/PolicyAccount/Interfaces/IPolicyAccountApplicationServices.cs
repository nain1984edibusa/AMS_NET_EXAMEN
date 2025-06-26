using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.ClosePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.CreatePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.RegisterInPayments;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Interfaces
{
    public interface IPolicyAccountApplicationServices
    {
        ICommandUseCase<CreatePolicyAccountCommand> CreatePolicyAccount { get; }
        ICommandUseCase<ClosePolicyAccountCommand> ClosePolicyAccount { get; }
        IQueryUseCase<GetPolicyAccountByNumberQuery, GetPolicyAccountByNumberResult> GetPolicyAccountByNumber { get; }
        ICommandUseCase<RegisterInPaymentsCommand> RegisterInPayments { get; }
    }
}