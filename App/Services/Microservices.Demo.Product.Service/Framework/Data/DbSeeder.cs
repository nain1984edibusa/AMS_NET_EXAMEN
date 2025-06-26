using Microservices.Demo.Products.Service.Domain.Products.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Products.Service.Framework.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IUnitOfWork uow)
        {
            await uow.EnsureCreatedAsync();
            if (await uow.Products.AnyAsync()) return;

            await uow.Products.AddAsync(DemoProductFactory.Travel());
            await uow.Products.AddAsync(DemoProductFactory.House());
            await uow.Products.AddAsync(DemoProductFactory.Farm());
            await uow.Products.AddAsync(DemoProductFactory.Car());

            await uow.CompleteAsync();
        }
    }
}
