using MediatR;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using System.Diagnostics;
using PolicyAccountEntity=Microservices.Demo.Payments.Service.Domain.Payments.Entities.PolicyAccount;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.CreatePolicyAccount
{
    public class CreatePolicyAccountUseCase : ICommandUseCase<CreatePolicyAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ActivitySource _activitySource;
        public CreatePolicyAccountUseCase(IUnitOfWork unitOfWork, ActivitySource activitySource)
        {
            _unitOfWork = unitOfWork;
            _activitySource = activitySource;
        }
        public async Task ExecuteAsync(CreatePolicyAccountCommand command)
        {
            using var activity = _activitySource.StartActivity("CreatePolicyAccountUseCase.ExecuteAsync", ActivityKind.Internal);

            var policyAccount = new PolicyAccountEntity
            (
                command.PolicyNumber,
                Guid.NewGuid().ToString(),
                command.PolicyHolder.FirstName,
                command.PolicyHolder.LastName
            );

            if (!await _unitOfWork.PolicyAccounts.ExistsWithPolicyNumber(command.PolicyNumber))
            {
                await _unitOfWork.PolicyAccounts.AddAsync(policyAccount);
                await _unitOfWork.CompleteAsync();

                activity.SetTagsFromObject(policyAccount, "PolicyAccount");
                activity.SetStatus(ActivityStatusCode.Ok);
            }
            else
            {
                activity.SetStatus(ActivityStatusCode.Error, $"Policy account {command.PolicyNumber} already exists.");
            }            
        }
    }
}
