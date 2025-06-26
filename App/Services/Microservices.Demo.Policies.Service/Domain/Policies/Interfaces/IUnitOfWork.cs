using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Policies.Service.Domain.Policies.Interfaces
{
    public interface IUnitOfWork : IGenericUnitOfWork
    {       
        IOfferRepository Offers { get; }
        IPolicyRepository Policies { get; }
    }
}
