using Microservices.Demo.Policies.Search.Service.Application.ReadModels.Policies.Interfaces;
using Microservices.Demo.Policies.Search.Service.Application.UseCases.Policy.Interfaces;

namespace Microservices.Demo.Policies.Search.Service.Framework.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(IReadModelUnitOfWork uow)
        {
            await uow.EnsureCreatedAsync();            
        }
    }
}
