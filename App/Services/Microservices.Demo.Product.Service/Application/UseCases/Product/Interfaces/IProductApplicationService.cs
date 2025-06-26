using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Interfaces
{
    public interface IProductApplicationService
    {
        IQueryUseCase<GetAllProductsQuery, GetAllProductsResult> GetAllProducts { get; }
        IQueryUseCase<GetProductByCodeQuery, GetProductByCodeResult> GetProductByCode { get; }
        ICommandUseCase<CreateProductCommand, CreateProductResult> CreateProduct { get; }
        ICommandUseCase<ActivateProductCommand, ActivateProductResult> ActivateProduct { get; }
        ICommandUseCase<DiscontinueProductCommand, DiscontinueProductResult> DiscontinueProduct { get; }
    }
}