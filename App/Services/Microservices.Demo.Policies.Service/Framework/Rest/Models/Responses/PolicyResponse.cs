
using Microservices.Demo.Policies.Service.Framework.Rest.Models.Dtos;

namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Responses
{
    public class PolicyResponse
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        //public string PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public string ProductCode { get; set; }
        public string AccountNumber { get; set; }

        public List<string> Covers { get; set; }

        public PolicyHolderDto PolicyHolder { get; set; }
    }
}
