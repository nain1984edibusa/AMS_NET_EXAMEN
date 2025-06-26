using Marten;
using Microservices.SharedKernel.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories
{
    public class MartenGenericRepository<T, TDocumentSession>
        : MartenReadOnlyRepository<T, TDocumentSession>, IGenericRepository<T>
        where T : class
        where TDocumentSession : IDocumentSession
    {
        public MartenGenericRepository(TDocumentSession session)
            : base(session)
        {
        }
        public Task AddAsync(T entity)
        {
            _session.Insert(entity);
            return Task.CompletedTask;
        }

        public void Remove(T entity)
        {
            _session.Delete(entity);
        }
        public void Update(T entity)
        {
            _session.Update(entity);
        }
        public void Upsert(T entity)
        {
            _session.Store(entity);
        }
    }
}
