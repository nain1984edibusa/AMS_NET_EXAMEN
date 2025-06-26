using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated;
using Microservices.SharedKernel.Application.ReadModels.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces
{
    public interface IPolicyProjectionService
    {
        IEventProjection<PolicyCreatedEvent> PolicyCreated { get; }
    }
}