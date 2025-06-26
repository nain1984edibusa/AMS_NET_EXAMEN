using MediatR;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.ClosePolicyAccount
{
    public class ClosePolicyAccountUseCase : ICommandUseCase<ClosePolicyAccountCommand>
    {
        private IUnitOfWork _unitOfWork;
        private readonly ActivitySource _activitySource;
        public ClosePolicyAccountUseCase(IUnitOfWork unitOfWork,ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _activitySource = activitySource;
        }
        public async Task ExecuteAsync(ClosePolicyAccountCommand command)
        {
            using var activity = _activitySource.StartActivity("ClosePolicyAccountUseCase.ExecuteAsync", ActivityKind.Internal);

            var policyAccount = await _unitOfWork.PolicyAccounts.FindByNumber(command.PolicyNumber);

            policyAccount.Close(command.PolicyTo, command.AmountToReturn);

            _unitOfWork.PolicyAccounts.Update(policyAccount);

            await _unitOfWork.CompleteAsync();

            activity.SetTagsFromObject(policyAccount, "PolicyAccount");
            activity.SetStatus(ActivityStatusCode.Ok);
        }
    }
}
