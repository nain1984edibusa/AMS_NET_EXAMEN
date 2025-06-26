using AutoMapper;
using PersonMessageDto=Microservices.Demo.Messages.Services.Policies.Dtos.PersonDto;
using PolicyCreatedEventMessage=Microservices.Demo.Messages.Services.Policies.Events.PolicyCreatedEvent;
using PolicyCreatedEventProjection = Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Projections.PolicyCreated.PolicyCreatedEvent;
using PersonProjectionDto=Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Dtos.PersonDto;

namespace Microservices.Demo.Policies.Search.Service.Framework.Messaging.Mappings
{
    public class MessagingPolicyProfile:Profile
    {
        public MessagingPolicyProfile()
        {
            CreateMap<PolicyCreatedEventMessage, PolicyCreatedEventProjection>();
            CreateMap<PersonMessageDto, PersonProjectionDto>();
        }
    }
}
