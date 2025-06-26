using Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Requests
{
    public class CreateOfferRequest
    {
        public string ProductCode { get; set; }
        public DateTime PolicyFrom { get; set; }
        public DateTime PolicyTo { get; set; }
        public List<string> SelectedCovers { get; set; }
        public List<QuestionAnswerDto> Answers { get; set; }
    }
}
