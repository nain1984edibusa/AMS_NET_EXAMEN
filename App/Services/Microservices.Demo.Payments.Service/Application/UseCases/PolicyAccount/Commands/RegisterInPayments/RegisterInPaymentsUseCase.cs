using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;
using Microservices.Demo.Payments.Service.Infrastructure.Files;
using Microservices.Infrastructure.Trace;
using Microservices.SharedKernel.Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.RegisterInPayments
{
    public class RegisterInPaymentsUseCase : ICommandUseCase<RegisterInPaymentsCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ActivitySource _activitySource;
        public RegisterInPaymentsUseCase(
            IUnitOfWork unitOfWork,
            ActivitySource activitySource
        )
        {
            _unitOfWork = unitOfWork;
            _activitySource = activitySource;
        }

        public async Task ExecuteAsync(RegisterInPaymentsCommand input)
        {
            using var activity = _activitySource.StartActivity("RegisterInPaymentsUseCase.ExecuteAsync", ActivityKind.Internal);

            var fileToImport = new BankStatementFile(input.Directory, input.Date);

            if (!fileToImport.Exists()) return;

            foreach (var txLine in fileToImport.Read())
            {
                var account = await _unitOfWork.PolicyAccounts.FindByNumber(txLine.AccountNumber);
                account?.InPayment(txLine.Amount, txLine.AccountingDate);

                _unitOfWork.PolicyAccounts.Update(account);
            }

            fileToImport.MarkProcessed();

            await _unitOfWork.CompleteAsync();

            activity.SetTagsFromObject(fileToImport, "BankStatementFile");
            activity.SetStatus(ActivityStatusCode.Ok);
        }
    }
}
