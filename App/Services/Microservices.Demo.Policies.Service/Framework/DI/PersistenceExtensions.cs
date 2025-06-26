using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts;
using Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Policies.Service.Framework.DI
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager config)
        {
            services.AddDbContext<PoliciesDbContext>(options =>
            {
                options.UseMySql(config.GetConnectionString("PoliciesConnection"),new MySqlServerVersion(new Version(9,3,0)))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
            });

            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IPolicyRepository, PolicyRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
