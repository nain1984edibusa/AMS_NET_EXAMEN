using AutoMapper;
using MediatR;
using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using PolicyCreatedEventProjection=Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated.PolicyCreatedEvent;

namespace Microservices.Demo.Policies.Search.Service.Framework.Messaging.Policy.Inbox.Events
{
    public class PolicyCreatedEventHandler : IRequestHandler<PolicyCreatedEvent>
    {
        private readonly IPolicyProjectionService _policyProjectionService;
        private readonly IMapper _mapper;   
        public PolicyCreatedEventHandler(IPolicyProjectionService policyProjectionService, IMapper mapper)
        {
            _policyProjectionService = policyProjectionService;
            _mapper = mapper;
        }
        public async Task Handle(PolicyCreatedEvent @event, CancellationToken cancellationToken)
        {
            var policyCreatedEvent = _mapper.Map<PolicyCreatedEventProjection>(@event);
            await _policyProjectionService.PolicyCreated.ExecuteAsync(policyCreatedEvent);
        }
    }
}
