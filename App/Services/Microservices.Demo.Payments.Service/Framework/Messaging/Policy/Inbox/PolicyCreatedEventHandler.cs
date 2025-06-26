using AutoMapper;
using ImTools;
using MediatR;
using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.CreatePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Interfaces;

namespace Microservices.Demo.Payments.Service.Framework.Messaging.Policy.Inbox
{
    public class PolicyCreatedEventHandler : IRequestHandler<PolicyCreatedEvent>
    {
        private readonly IPolicyAccountApplicationServices _policyAccountApplicationServices;
        private readonly IMapper _mapper;
        public PolicyCreatedEventHandler(IPolicyAccountApplicationServices policyAccountApplicationServices, IMapper mapper)
        {
            _policyAccountApplicationServices = policyAccountApplicationServices;
            _mapper = mapper;
        }
        public async Task Handle(PolicyCreatedEvent @event, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreatePolicyAccountCommand>(@event);
            await _policyAccountApplicationServices.CreatePolicyAccount.ExecuteAsync(command);
        }
    }
}
