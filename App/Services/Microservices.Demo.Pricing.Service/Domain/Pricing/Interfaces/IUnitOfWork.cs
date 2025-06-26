using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces
{
    public interface IUnitOfWork: IGenericUnitOfWork
    {
        ITariffRepository Tariffs { get; }
    }
}
