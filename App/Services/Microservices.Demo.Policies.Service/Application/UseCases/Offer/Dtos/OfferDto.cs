namespace Microservices.Demo.Policies.Service.Application.UseCases.Offer.Dtos
{
    public class OfferDto
    {
        public string OfferNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public Dictionary<string, decimal> CoversPrices { get; set; }

        public static OfferDto Empty()
        {
            return new OfferDto { CoversPrices = new Dictionary<string, decimal>() };
        }
    }
}
