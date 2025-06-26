using Microservices.SharedKernel.Domain.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Models
{
    public class PolicyReadModel: IAggregateRoot
    {
        public string Id { get; set; }
        public string PolicyNumber { get; set; }
        public DateTimeOffset PolicyStartDate { get; set; }
        public DateTimeOffset PolicyEndDate { get; set; }
        public string ProductCode { get; set; }
        public string PolicyHolder { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}
