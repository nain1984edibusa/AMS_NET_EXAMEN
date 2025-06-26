using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOfferByAgent;
using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Interfaces;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Services
{
    public class OfferApplicationService : IOfferApplicationService
    {
        public ICommandUseCase<CreateOfferCommand, CreateOfferResult> CreateOffer { get; }
        public ICommandUseCase<CreateOfferByAgentCommand, CreateOfferByAgentResult> CreateOfferByAgent { get; }


        public OfferApplicationService(
            ICommandUseCase<CreateOfferCommand, CreateOfferResult> createOffer,
            ICommandUseCase<CreateOfferByAgentCommand, CreateOfferByAgentResult> createOfferByAgent
        )
        {
            CreateOffer = createOffer;
            CreateOfferByAgent = createOfferByAgent;
        }
    }
}
