namespace Microservices.Demo.Payments.Service.Framework.Rest.Models.Dtos
{
    public class PolicyAccountBalanceDto
    {
        public string PolicyAccountNumber { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Balance { get; set; }
    }
}
