using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer
{
    public class CreateOfferResult : OfferDto, ICommandResult { }
}
