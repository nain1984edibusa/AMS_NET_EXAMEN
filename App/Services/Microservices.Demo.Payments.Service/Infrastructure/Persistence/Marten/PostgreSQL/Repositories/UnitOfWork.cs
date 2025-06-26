using Marten;
using Microservices.Demo.Payments.Service.Domain.Payments;
using Microservices.Demo.Payments.Service.Domain.Payments.Entities;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;
using Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories;
using static Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.MartenClients.MartenExtensions;

namespace Microservices.Demo.Payments.Service.Infrastructure.Persistence.Marten.PostgreSQL.Repositories
{
    public class UnitOfWork : MartenGenericUnitOfWork<IDocumentSession>, IUnitOfWork
    {        
        public IPolicyAccountRepository PolicyAccounts { get; }

        public UnitOfWork(
            IDocumentStore documentStore,
            IDocumentSession session,
            MartenDatabaseOptions options,
            IPolicyAccountRepository policyAccounts
        ) : base(documentStore,session,options)
        {            
            PolicyAccounts = policyAccounts;
        }
    }
}
