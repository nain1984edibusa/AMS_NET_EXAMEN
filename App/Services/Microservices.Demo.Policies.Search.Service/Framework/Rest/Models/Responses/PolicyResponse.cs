namespace Microservices.Demo.Policies.Search.Service.Framework.Rest.Models.Responses
{
    public class PolicyResponse
    {
        public string PolicyNumber { get; set; }
        public DateTimeOffset PolicyStartDate { get; set; }
        public DateTimeOffset PolicyEndDate { get; set; }
        public string ProductCode { get; set; }
        public string PolicyHolder { get; set; }
        public decimal PremiumAmount { get; set; }
    }
}
