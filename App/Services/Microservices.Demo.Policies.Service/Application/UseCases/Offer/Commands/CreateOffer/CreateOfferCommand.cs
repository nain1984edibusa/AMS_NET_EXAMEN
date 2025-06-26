using Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Commands.CreateOffer
{
    public class CreateOfferCommand:ICommand
    {
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; }
    }
}
