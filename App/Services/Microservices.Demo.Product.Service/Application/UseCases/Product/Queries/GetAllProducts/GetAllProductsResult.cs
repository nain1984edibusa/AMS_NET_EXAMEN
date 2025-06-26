using Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts
{
    public class GetAllProductsResult : IQueryResult{
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
