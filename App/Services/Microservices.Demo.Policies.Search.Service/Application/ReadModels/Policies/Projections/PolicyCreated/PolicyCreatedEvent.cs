using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Dtos;
using Microservices.SharedKernel.Application.ReadModels.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated
{
    public class PolicyCreatedEvent:IEvent
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
