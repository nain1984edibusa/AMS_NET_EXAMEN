using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.ClosePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.CreatePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.RegisterInPayments;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Interfaces;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Queries.GetPolicyAccountByNumber;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Services
{
    public class PolicyAccountApplicationServices : IPolicyAccountApplicationServices
    {
        public ICommandUseCase<CreatePolicyAccountCommand> CreatePolicyAccount { get; }
        public ICommandUseCase<ClosePolicyAccountCommand> ClosePolicyAccount { get; }
        public ICommandUseCase<RegisterInPaymentsCommand> RegisterInPayments { get; }
        public IQueryUseCase<GetPolicyAccountByNumberQuery, GetPolicyAccountByNumberResult> GetPolicyAccountByNumber { get; }

        public PolicyAccountApplicationServices(
            ICommandUseCase<CreatePolicyAccountCommand> createPolicyAccount,
            ICommandUseCase<ClosePolicyAccountCommand> closePolicyAccount,
            ICommandUseCase<RegisterInPaymentsCommand> registerInPayments,
            IQueryUseCase<GetPolicyAccountByNumberQuery, GetPolicyAccountByNumberResult> getPolicyAccountByNumber
        )
        {
            CreatePolicyAccount = createPolicyAccount;
            ClosePolicyAccount = closePolicyAccount;
            RegisterInPayments = registerInPayments;
            GetPolicyAccountByNumber = getPolicyAccountByNumber;
        }
    }
}
