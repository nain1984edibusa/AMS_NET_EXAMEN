using Marten;
using Microservices.SharedKernel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories
{
    public class MartenRepository<T, TDocumentSession>
        : MartenGenericRepository<T, TDocumentSession>, IRepository<T>
        where T : class, IAggregateRoot
        where TDocumentSession : IDocumentSession
    {
        public MartenRepository(TDocumentSession session) : base(session) { }
    }
}
