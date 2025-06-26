namespace Microservices.Demo.Reports.Service.Application.Dtos
{
    public class PolicyDto
    {
        //public string Id { get; set; } = default!;
        //public string Number { get; set; } = default!;
        //public string ProductId { get; set; } = default!;

        //public string number { get; set; }
        //public DateTime dateFrom { get; set; }
        //public DateTime dateTo { get; set; }
        //public string policyHolder { get; set; }
        //public decimal totalPremium { get; set; }
        //public string productCode { get; set; }
        //public string accountNumber { get; set; }
        //public List<string> covers  {get; set; }

        public string Id { get; set; }
        public string Number { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string PolicyHolder { get; set; }
        public decimal TotalPremium { get; set; }
        public string ProductCode { get; set; }
        public string? AccountNumber { get; set; }
        //public List<CoverDto> Covers { get; set; }
    }
}
