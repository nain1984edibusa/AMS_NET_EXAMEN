using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Interfaces
{
    public interface IOfferApplicationService
    {
        ICommandUseCase<CreateOfferCommand, CreateOfferResult> CreateOffer { get; }
        ICommandUseCase<CreateOfferByAgentCommand, CreateOfferByAgentResult> CreateOfferByAgent { get; }
    }
}