using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated;
using Microservices.SharedKernel.Application.ReadModels.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Services
{
    public class PolicyProjectionService : IPolicyProjectionService
    {
        public IEventProjection<PolicyCreatedEvent> PolicyCreated { get; }

        public PolicyProjectionService(IEventProjection<PolicyCreatedEvent> policyCreated)
        {
            PolicyCreated = policyCreated;
        }
    }
}
