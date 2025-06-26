namespace Microservices.Demo.Products.Service.Framework.Rest.Models.Responses
{
    public class GetAllProductsResponse
    {
        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public List<ProductResponse> Products { get; set; } = new List<ProductResponse>();
    }
}
