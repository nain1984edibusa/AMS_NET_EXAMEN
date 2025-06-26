using ImTools;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces;
using Microservices.Demo.Pricing.Service.Infrastructure.Persistence.Marten.PostgreSQL.Repositories;
using Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients;
using Microsoft.Extensions.Configuration;
using static Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients.MartenExtensions;

namespace Microservices.Demo.Pricing.Service.Framework.DI
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager configuration)
        {            
            services.AddMartenDocumentStore(opt =>
            {
                opt.Database.ConnectionString = configuration.GetConnectionString("PricingConnection");
                opt.Database.SchemaName = "policies_Service";
                opt.Database.AutoCreateSchema = true;

                opt.Documents = MartenDocumentOptionsBuilder.Create(
                    new MartenExtensions.MartenDocumentOptions<Tariff>
                    {
                        PropertyExpression = t => t.Code,
                        SqlType = "varchar(50)",
                        IsUnique = true
                    }
                );
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITariffRepository, TariffRepository>();

            return services;
        }
    }
}
