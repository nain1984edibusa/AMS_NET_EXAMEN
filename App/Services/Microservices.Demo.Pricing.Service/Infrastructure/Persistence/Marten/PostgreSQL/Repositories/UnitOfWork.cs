using Marten;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces;
using Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories;
using static Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients.MartenExtensions;

namespace Microservices.Demo.Pricing.Service.Infrastructure.Persistence.Marten.PostgreSQL.Repositories
{

    public class UnitOfWork : MartenGenericUnitOfWork<IDocumentSession>, IUnitOfWork
    {        
        public ITariffRepository Tariffs { get; }

        public UnitOfWork(
            IDocumentStore documentStore,
            IDocumentSession session,
            MartenDatabaseOptions options,
            ITariffRepository tariffs
        ):base(documentStore, session, options)
        {            
            Tariffs = tariffs;
        }
    }
}
