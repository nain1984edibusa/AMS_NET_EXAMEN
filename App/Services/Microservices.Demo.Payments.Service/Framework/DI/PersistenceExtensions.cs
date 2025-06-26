using Microservices.Demo.Payments.Service.Domain.Payments;
using Microservices.Demo.Payments.Service.Domain.Payments.Entities;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;
using Microservices.Demo.Payments.Service.Infrastructure.Persistence.Marten.PostgreSQL.Repositories;
using Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients;
using static Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients.MartenExtensions;

namespace Microservices.Demo.Payments.Service.Framework.DI
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddMartenDocumentStore(opt =>
            {
                opt.Database.ConnectionString = configuration.GetConnectionString("PaymentsConnection");
                opt.Database.SchemaName = "payments_Service";
                opt.Database.AutoCreateSchema = true;

                opt.Documents = MartenDocumentOptionsBuilder.Create(
                    new MartenExtensions.MartenDocumentOptions<PolicyAccount>
                    {
                        PropertyExpression = t => t.PolicyNumber,
                        SqlType = "varchar(50)",
                        IsUnique = true
                    }
                );
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPolicyAccountRepository, PolicyAccountRepository>();

            return services;
        }
    }
}
