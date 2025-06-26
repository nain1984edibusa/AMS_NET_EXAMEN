using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.CreatePolicyAccount
{
    public class CreatePolicyAccountCommand:ICommand
    {
        public string PolicyNumber { get; set; }
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public PersonDto PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public string AgentLogin { get; set; }
    }
}
