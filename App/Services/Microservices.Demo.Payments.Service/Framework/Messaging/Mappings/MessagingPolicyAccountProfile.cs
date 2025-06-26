using AutoMapper;
using Microservices.Demo.Messages.Services.Policies.Events;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.ClosePolicyAccount;
using Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Commands.CreatePolicyAccount;
using PersonAppDto=Microservices.Demo.Payments.Service.Application.UseCases.PolicyAccount.Dtos.PersonDto;
using PersonMessageDto=Microservices.Demo.Messages.Services.Policies.Dtos.PersonDto;

namespace Microservices.Demo.Payments.Service.Framework.Messaging.Mappings
{
    public class MessagingPolicyAccountProfile:Profile
    {
        public MessagingPolicyAccountProfile()
        {
            CreateMap<PolicyCreatedEvent, CreatePolicyAccountCommand>();
            CreateMap<PolicyTerminatedEvent,ClosePolicyAccountCommand>();
            CreateMap<PersonMessageDto, PersonAppDto>();
        }
    }
}
