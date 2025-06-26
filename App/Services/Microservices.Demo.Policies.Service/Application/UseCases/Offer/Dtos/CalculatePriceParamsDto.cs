namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos
{
    public class CalculatePriceParamsDto
    {
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<AnswerDto> Answers { get; set; }

    }
}
