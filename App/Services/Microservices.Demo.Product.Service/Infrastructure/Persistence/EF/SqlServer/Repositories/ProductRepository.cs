using Microservices.Demo.Products.Service.Domain.Products.Entities;
using Microservices.Demo.Products.Service.Domain.Products.Enums;
using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts;
using Microservices.Infrastructure.Persistences.EF.Relational.Generic;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Repositories
{
    public class ProductRepository : Repository<Product, ProductsDbContext>, IProductRepository
    {
        public ProductRepository(ProductsDbContext context) : base(context) { }
                
        public override async Task<Product> AddAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        public async Task<List<Product>> FindAllActive()
        {
            return await _context
                .Products
                .Include(c => c.Covers)
                .Include("Questions.Choices")
                .Where(p => p.Status == ProductStatus.Active)
                .ToListAsync();
        }

        public async Task<Product> FindOne(string productCode)
        {
            return await _context
                .Products
                .Include(c => c.Covers)
                .Include("Questions.Choices")
                .FirstOrDefaultAsync(p => p.Code.ToLower() == productCode.ToLower());
        }

        public async Task<Product> FindById(Guid id)
        {
            return await _context.Products.Include(c => c.Covers).Include("Questions.Choices")
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
