using Microservices.Demo.RestClients.Pricing.Models.Dtos;

namespace Microservices.Demo.RestClients.Pricing.Models.Requests
{
    public class CalculatePriceRequest
    {
        public string ProductCode { get; set; }
        public DateTimeOffset PolicyFrom { get; set; }
        public DateTimeOffset PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; }
    }
}
