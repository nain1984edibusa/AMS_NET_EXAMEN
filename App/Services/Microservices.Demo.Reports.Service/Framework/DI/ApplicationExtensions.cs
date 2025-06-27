using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Reports.Service.Framework.DI
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddScoped<IQueryUseCase<GetAllProductsQuery, GetAllProductsResult>, GetAllProductsUseCase>();
            //services.AddScoped<IQueryUseCase<GetProductByCodeQuery, GetProductByCodeResult>, GetProductByCodeUseCase>();

            //services.AddScoped<ICommandUseCase<CreateProductCommand, CreateProductResult>, CreateProductUseCase>();
            //services.AddScoped<ICommandUseCase<ActivateProductCommand, ActivateProductResult>, ActivateProductUseCase>();
            //services.AddScoped<ICommandUseCase<DiscontinueProductCommand, DiscontinueProductResult>, DiscontinueProductUseCase>();

            //services.AddScoped<IProductApplicationService, ProductApplicationService>();


            return services;
        }
    }
}
