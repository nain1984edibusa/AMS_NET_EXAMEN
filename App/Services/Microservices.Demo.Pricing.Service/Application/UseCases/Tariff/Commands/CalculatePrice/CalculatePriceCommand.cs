using Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Pricing.Service.Application.UseCases.Tariff.Commands.CalculatePrice
{
    public class CalculatePriceCommand: ICommand
    {
        public string ProductCode { get; set; }
        public DateTimeOffset PolicyFrom { get; set; }
        public DateTimeOffset PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; }
    }
}
