using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.SharedKernel.Domain.Interfaces;

namespace Microservices.Demo.Products.Service.Domain.Products.Interfaces;

public interface IProductRepository: IRepository<Product>
{    
    Task<List<Product>> FindAllActive();
    Task<Product> FindOne(string productCode);
    Task<Product> FindById(Guid id);
}