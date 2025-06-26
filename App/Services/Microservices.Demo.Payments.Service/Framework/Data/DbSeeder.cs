using Microservices.Demo.Payments.Service.Domain.Payments.Entities;
using Microservices.Demo.Payments.Service.Domain.Payments.Interfaces;

namespace Microservices.Demo.Payments.Service.Framework.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(IUnitOfWork uow)
        {
            await uow.EnsureCreatedAsync();

            foreach (var demoAccount in DemoPolicyAccountsFactory.DemoPolicyAccounts()) 
                await AddIfNotExists(demoAccount, uow);
                        
            await uow.CompleteAsync();
        }
        private static async Task AddIfNotExists(PolicyAccount account, IUnitOfWork uow)
        {            
            if (await uow.PolicyAccounts.FindByNumber(account.PolicyNumber) == null)
                await uow.PolicyAccounts.AddAsync(account);
        }
    }
}
