using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent
{
    public class CreateOfferByAgentResult : OfferDto, ICommandResult { }
}
