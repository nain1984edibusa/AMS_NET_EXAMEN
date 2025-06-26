namespace Microservices.Demo.Pricing.Service.Framework.Rest.Models.Responses
{
    public class CalculatePriceResponse
    {
        public decimal TotalPrice { get; set; }
        public Dictionary<string, decimal> CoverPrices { get; set; }
    }
}
