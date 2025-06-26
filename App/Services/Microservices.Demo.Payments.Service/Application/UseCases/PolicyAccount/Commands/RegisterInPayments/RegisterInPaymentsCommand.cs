using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.RegisterInPayments
{
    public class RegisterInPaymentsCommand : ICommand
    {
        public string Directory { get; set; }
        public DateTimeOffset Date { get; set; }
        public RegisterInPaymentsCommand(string directory, DateTimeOffset date)
        {
            Directory = directory;
            Date = date;
        }        
    }
}
