using Microservices.Demo.Messages.Services.Policies.Dtos;
using Microservices.Messages.Base;

namespace Microservices.Demo.Messages.Services.Policies.Events
{
    public class PolicyTerminatedEvent: Event
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
