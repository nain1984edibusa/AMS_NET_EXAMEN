namespace Microservices.Demo.RestClients.Pricing.Models.Response
{
    public class CalculatePriceResponse
    {
        public decimal TotalPrice { get; set; }
        public Dictionary<string, decimal> CoverPrices { get; set; }
    }
}
