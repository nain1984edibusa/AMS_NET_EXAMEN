using Microservices.SharedKernel.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Microservices.Infrastructure.Persistences.EF.Relational.Generic
{
    public class GenericRepository<T, TDbContext>
        : ReadOnlyRepository<T, TDbContext>, IGenericRepository<T>
        where T : class
        where TDbContext : DbContext
    {
        public GenericRepository(TDbContext context)
            : base(context)
        {
        }

        public virtual async Task AddAsync(T entity)
            => await _context.Set<T>().AddAsync(entity);

        public virtual void Update(T entity)
           => _context.Set<T>().Update(entity);

        public virtual void Upsert(T entity)
            => _context.Set<T>().Update(entity);

        public virtual void Remove(T entity)
            => _context.Set<T>().Remove(entity);
    }

}
