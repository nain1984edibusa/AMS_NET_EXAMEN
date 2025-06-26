using Microservices.Demo.Reports.Service.Application.Dtos;

namespace Microservices.Demo.Reports.Service.Application.Interfaces
{
    public interface IProductClient
    {
        Task<ProductDto?> GetProductByIdAsync(string productId);
        Task<ProductDto?> GetProductByCodeAsync(string productCode);
    }
}
