namespace Microservices.Demo.Policies.Service.Application.UseCases.Policy.Dtos
{
    public class PolicyDto
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public string ProductCode { get; set; }
        public string AccountNumber { get; set; }
        public List<string> Covers { get; set; }
    }
}
