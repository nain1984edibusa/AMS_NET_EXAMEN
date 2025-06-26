namespace Microservices.Demo.Products.Service.Framework.Rest.Models.Requests
{
    public class GetAllProductsRequest
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? Search { get; set; }
    }
}
