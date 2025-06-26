using Microservices.Demo.Products.Service.Application.UseCases.Product.Dtos;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode
{
    public class GetProductByCodeResult : ProductDto, IQueryResult { }
}
