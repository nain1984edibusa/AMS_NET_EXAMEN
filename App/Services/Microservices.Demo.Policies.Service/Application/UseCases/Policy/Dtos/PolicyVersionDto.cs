
using Microservices.Demo.Policies.Service.Domain.Policies.ValueObjects;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos
{
    public class PolicyVersionDto
    {

        public decimal TotalPremiumAmount { get; set; }

        public PolicyHolder PolicyHolder { get; set; }
    }
}
