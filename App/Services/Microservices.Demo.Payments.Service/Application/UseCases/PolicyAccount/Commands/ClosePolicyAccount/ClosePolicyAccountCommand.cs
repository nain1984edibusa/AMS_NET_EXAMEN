using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Dtos;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.ClosePolicyAccount
{
    public class ClosePolicyAccountCommand:ICommand
    {
        public string PolicyNumber { get; set; }
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public PersonDto PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public decimal AmountToReturn { get; set; }
    }
}
