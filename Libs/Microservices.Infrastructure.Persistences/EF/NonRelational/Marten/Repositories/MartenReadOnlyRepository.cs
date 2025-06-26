using Marten;
using Microservices.SharedKernel.Domain.Interfaces;
using Microservices.SharedKernel.Domain.Specifications;
using System.Linq.Expressions;

namespace Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories
{
    public class MartenReadOnlyRepository<T, TDocumentSession>
                : IReadOnlyRepository<T>
                where T : class
                where TDocumentSession : IDocumentSession
    {
        protected readonly IDocumentSession _session;

        public MartenReadOnlyRepository(IDocumentSession session)
        {
            _session = session;
        }

        public virtual async Task<bool> AnyAsync()
        {
            return await _session.Query<T>().AnyAsync();
        }
        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _session.Query<T>().AnyAsync(predicate);
        }
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _session.Query<T>().Where(predicate).ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> FindAsync(ISpecification<T> specification)
        {
            return await _session.Query<T>()
                         .Where(specification.Criteria)
                         .ToListAsync();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _session.Query<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
        {
            return await _session.LoadAsync<T>(id);
        }
    }
}
