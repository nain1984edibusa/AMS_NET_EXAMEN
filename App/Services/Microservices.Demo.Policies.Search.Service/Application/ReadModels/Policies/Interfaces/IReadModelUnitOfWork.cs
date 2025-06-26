using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces
{
    public interface IReadModelUnitOfWork : IGenericUnitOfWork
    {
        IReadModelPolicyRepository Policies { get; }
    }
}
