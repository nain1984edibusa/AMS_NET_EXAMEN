using Microservices.SharedKernel.Domain.Interfaces;
using Microservices.SharedKernel.Domain.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Microservices.Infrastructure.Persistences.EF.Relational.Generic
{
    public class ReadOnlyRepository<T, TDbContext>
        : IReadOnlyRepository<T>
        where T : class
        where TDbContext : DbContext
    {
        protected readonly TDbContext _context;

        public ReadOnlyRepository(TDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> GetByIdAsync(Guid id)
            => await _context.Set<T>().FindAsync(id);

        public virtual async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().Where(predicate).ToListAsync();

        public virtual async Task<IEnumerable<T>> FindAsync(ISpecification<T> specification)
           => await _context.Set<T>()
               .Where(specification.Criteria)
               .ToListAsync();

        public virtual async Task<bool> AnyAsync()
            => await _context.Set<T>().AnyAsync();

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
            => await _context.Set<T>().AnyAsync(predicate);

    }
}
