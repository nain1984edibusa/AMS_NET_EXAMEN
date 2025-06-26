using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Interfaces;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Application.UseCases.Product.Services
{
    public class ProductApplicationService : IProductApplicationService
    {
        public IQueryUseCase<GetAllProductsQuery, GetAllProductsResult> GetAllProducts { get; }
        public IQueryUseCase<GetProductByCodeQuery, GetProductByCodeResult> GetProductByCode { get; }
        public ICommandUseCase<CreateProductCommand,CreateProductResult> CreateProduct { get; }
        public ICommandUseCase<ActivateProductCommand, ActivateProductResult> ActivateProduct { get; }
        public ICommandUseCase<DiscontinueProductCommand, DiscontinueProductResult> DiscontinueProduct { get; }


        public ProductApplicationService(
            IQueryUseCase<GetAllProductsQuery, GetAllProductsResult> getAllProducts,
            IQueryUseCase<GetProductByCodeQuery, GetProductByCodeResult> getProductByCode,
            ICommandUseCase<CreateProductCommand, CreateProductResult> createProduct,
            ICommandUseCase<ActivateProductCommand, ActivateProductResult> activateProduct,
            ICommandUseCase<DiscontinueProductCommand, DiscontinueProductResult> discontinueProduct
        )
        {
            GetAllProducts = getAllProducts;
            GetProductByCode = getProductByCode;
            CreateProduct = createProduct;
            ActivateProduct = activateProduct;
            DiscontinueProduct = discontinueProduct;
        }
    }
}
