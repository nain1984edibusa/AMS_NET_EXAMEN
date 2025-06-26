using Microservices.SharedKernel.Application.UseCases.Interfaces;

namespace Microservices.Demo.Products.Service.Domain.Products.Interfaces
{
    public interface IUnitOfWork: IGenericUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
