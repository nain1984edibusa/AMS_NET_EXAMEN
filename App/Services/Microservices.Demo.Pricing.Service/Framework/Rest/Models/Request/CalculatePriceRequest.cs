using Microservices.Demo.Pricing.Service.Framework.Rest.Models.Dtos;

namespace Microservices.Demo.Pricing.Service.Framework.Rest.Models.Request
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
