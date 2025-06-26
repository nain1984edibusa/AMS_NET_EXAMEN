using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Contexts;
using Microservices.Infrastructure.Persistences.EF.Relational.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Products.Service.Infrastructure.Persistence.EF.SqlServer.Repositories
{
    public class UnitOfWork : GenericUnitOfWork<ProductsDbContext>, IUnitOfWork
    {
        public IProductRepository Products { get; }

        public UnitOfWork(
            ProductsDbContext context,
            IProductRepository products
        ) : base(context)
        {

            Products = products;
            
        }
    }
}
