using Microservices.SharedKernel.Application.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Infrastructure.Persistences.EF.Relational.Generic
{
    public class GenericUnitOfWork<TDbContext> : IGenericUnitOfWork where TDbContext : DbContext
    {
        private readonly TDbContext _context;
        
        public GenericUnitOfWork(
            TDbContext context            
        )
        {
            _context = context;
        }

        public async Task<int> CompleteAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public void Dispose()
            => _context.Dispose();

        public async Task EnsureCreatedAsync(CancellationToken cancellationToken = default)
        {
            await _context.Database.EnsureCreatedAsync(cancellationToken);
        }

        public async Task MigrateAsync(CancellationToken cancellationToken = default)
        {
            await _context.Database.MigrateAsync(cancellationToken);    
        }

        public async Task BeginTransactionAsync()
        {
            if (_context.Database.CurrentTransaction == null)
            {
                await _context.Database.BeginTransactionAsync();
            }
        }
        public async Task CommitTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.CommitAsync();
            }
        }
        public async Task RollbackTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.CurrentTransaction.RollbackAsync();
            }
        }
    }

}
