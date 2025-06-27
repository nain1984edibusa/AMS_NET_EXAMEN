using Microservices.Demo.Reports.Service.Application.Dtos;
using Microservices.Demo.Reports.Service.Application.Interfaces;

namespace Microservices.Demo.Reports.Service.Infrastructure.Clients
{
    public class ProductClient : IProductClient
    {
        private readonly HttpClient _httpClient;

        public ProductClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<ProductDto?> GetProductByCodeAsync(string productCode)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto?> GetProductByIdAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetProductDataAsync()
        {
            // Simula una llamada a products.service
            return await Task.FromResult("Product data from products.service");
        }
    }
}
