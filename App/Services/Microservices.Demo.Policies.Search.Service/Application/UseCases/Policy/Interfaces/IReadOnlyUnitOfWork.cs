
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces
{
    public interface IReadOnlyUnitOfWork : IGenericUnitOfWork
    {
        IPolicyReadOnlyRepository Policies { get; }
    }
}
