using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts;
using Microservices.Infrastructure.Persistences.EF.Relational.Generic;

namespace Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Repositories
{
    public class UnitOfWork : GenericUnitOfWork<PoliciesDbContext>, IUnitOfWork
    {
        public IOfferRepository Offers { get; }
        public IPolicyRepository Policies { get; }

        public UnitOfWork(
            PoliciesDbContext context,
            IOfferRepository offers,
            IPolicyRepository policies
        ) : base(context)
        {
            Offers = offers;
            Policies = policies;
        }
    }

}
