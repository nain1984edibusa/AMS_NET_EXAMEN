using System;
using System.Threading.Tasks;

namespace Microservices.SharedKernel.Application.UseCases.Interfaces
{
    public interface IGenericUnitOfWork : IDisposable
    {
        Task EnsureCreatedAsync(CancellationToken cancellationToken = default);
        Task MigrateAsync(CancellationToken cancellationToken = default);
        Task<int> CompleteAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
