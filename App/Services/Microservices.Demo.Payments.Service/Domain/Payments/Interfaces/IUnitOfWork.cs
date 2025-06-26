using Microservices.Demo.Payments.Service.Domain.Payments;
using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Payments.Service.Domain.Payments.Interfaces
{
    public interface IUnitOfWork : IGenericUnitOfWork
    {
        IPolicyAccountRepository PolicyAccounts { get; }
    }
}