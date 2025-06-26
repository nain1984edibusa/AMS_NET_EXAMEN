using AutoMapper;
using MediatR;
using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.ClosePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Interfaces;

namespace Microservices.Demo.Payments.Service.Framework.Messaging.Policy.Inbox
{
    public class PolicyTerminatedEventHandler : IRequestHandler<PolicyTerminatedEvent>
    {
        private readonly IPolicyAccountApplicationServices _policyAccountApplicationServices;
        private readonly IMapper _mapper;
        public PolicyTerminatedEventHandler(IPolicyAccountApplicationServices policyAccountApplicationServices, IMapper mapper)
        {
            _policyAccountApplicationServices = policyAccountApplicationServices;
            _mapper = mapper;
        }
        public async Task Handle(PolicyTerminatedEvent @event, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<ClosePolicyAccountCommand>(@event);
            await _policyAccountApplicationServices.ClosePolicyAccount.ExecuteAsync(command);
        }
    }
}
