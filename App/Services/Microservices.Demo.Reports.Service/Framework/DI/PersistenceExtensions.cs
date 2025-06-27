using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Reports.Service.Framework.DI
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager config)
        {
            //services.AddDbContext<ProductsDbContext>(options => {
            //    options.UseSqlServer(config.GetConnectionString("ProductsConnection"))
            //           .EnableSensitiveDataLogging()
            //           .EnableDetailedErrors();
            //});

            //services.AddScoped<IProductRepository, ProductRepository>();            
            //services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
