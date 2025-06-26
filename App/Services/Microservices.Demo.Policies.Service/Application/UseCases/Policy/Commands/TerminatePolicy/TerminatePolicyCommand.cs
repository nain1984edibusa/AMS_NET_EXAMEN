using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Commands.TerminatePolicy
{
    public class TerminatePolicyCommand:ICommand
    {
        public string PolicyNumber { get; set; }
        public DateTime TerminationDate { get; set; }
    }
}
