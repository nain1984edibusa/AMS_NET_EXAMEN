using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.TerminatePolicy
{
    public class TerminatePolicyResult:ICommandResult
    {
        public string PolicyNumber { get; set; }
        public decimal MoneyToReturn { get; set; }
    }
}
