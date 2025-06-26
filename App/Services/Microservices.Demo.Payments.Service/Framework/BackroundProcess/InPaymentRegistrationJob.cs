using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.RegisterInPayments;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Interfaces;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Services;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;

namespace Microservices.Demo.Payments.Service.Framework.Jobs
{
    public class InPaymentRegistrationJob
    {
        private readonly BackgroundProcessConfig _jobConfig;
        private readonly IPolicyAccountApplicationServices _policyAccountApplicationServices;

        public InPaymentRegistrationJob(        
            BackgroundProcessConfig jobConfig,
            IPolicyAccountApplicationServices policyAccountApplicationServices
        )
        {            
            _jobConfig = jobConfig;
            _policyAccountApplicationServices = policyAccountApplicationServices;
        }

        public async Task Run()
        {
            Console.WriteLine($"InPayment import started. Looking for file in {_jobConfig.InPaymentFileFolder}");

            var command = new RegisterInPaymentsCommand(_jobConfig.InPaymentFileFolder, DateTimeOffset.Now);
            await _policyAccountApplicationServices.RegisterInPayments.ExecuteAsync(command);            

            Console.WriteLine("InPayment import finished.");
        }
    }
}
