namespace Microservices.Demo.Policies.Service.Framework.Rest.Models.Responses
{
    public class OfferResponse
    {
        public string OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public Dictionary<string, decimal> CoversPrices { get; set; }

        public static OfferResponse Empty()
        {
            return new OfferResponse { CoversPrices = new Dictionary<string, decimal>() };
        }
    }
}
