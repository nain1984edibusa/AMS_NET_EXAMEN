using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.ActivateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.CreateProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Commands.DiscontinueProduct;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Interfaces;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetAllProducts;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Queries.GetProductByCode;
using Microservices.Demo.Products.Service.Application.UseCases.Product.Services;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Framework.DI
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IQueryUseCase<GetAllProductsQuery, GetAllProductsResult>, GetAllProductsUseCase>();
            services.AddScoped<IQueryUseCase<GetProductByCodeQuery, GetProductByCodeResult>, GetProductByCodeUseCase>();

            services.AddScoped<ICommandUseCase<CreateProductCommand, CreateProductResult>, CreateProductUseCase>();
            services.AddScoped<ICommandUseCase<ActivateProductCommand, ActivateProductResult>, ActivateProductUseCase>();
            services.AddScoped<ICommandUseCase<DiscontinueProductCommand, DiscontinueProductResult>, DiscontinueProductUseCase>();

            services.AddScoped<IProductApplicationService, ProductApplicationService>();


            return services;
        }
    }
}
