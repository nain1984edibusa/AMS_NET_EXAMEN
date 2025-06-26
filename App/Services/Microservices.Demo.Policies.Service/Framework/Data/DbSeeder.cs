using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microsoft.EntityFrameworkCore;
using IUnitOfWork = Microservices.Demo.Policies.Service.Domain.Policies.Interfaces.IUnitOfWork;

namespace Microservices.Demo.Policies.Service.Framework.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IUnitOfWork uow)
        {
            await uow.EnsureCreatedAsync();
            //await uow.MigrateAsync();            
        }
    }
}
