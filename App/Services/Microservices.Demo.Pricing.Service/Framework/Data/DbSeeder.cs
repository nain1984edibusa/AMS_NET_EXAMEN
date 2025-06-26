using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces;

namespace Microservices.Demo.Pricing.Service.Framework.Data
{
    public static class DbSeeder
    {
        private static readonly IDictionary<string, Func<Tariff>> builders = new Dictionary<string, Func<Tariff>>
        {
            { "TRI", DemoTariffFactory.Travel },
            { "HSI", DemoTariffFactory.House },
            { "FAI", DemoTariffFactory.Farm },
            { "CAR", DemoTariffFactory.Car }
        };

        public static async Task SeedAsync(IUnitOfWork uow)
        {
            await uow.EnsureCreatedAsync();

            await AddTariffIfNotExists("TRI", uow);
            await AddTariffIfNotExists("HSI", uow);
            await AddTariffIfNotExists("FAI", uow);
            await AddTariffIfNotExists("CAR", uow);

            await uow.CompleteAsync();
        }

        private static async Task AddTariffIfNotExists(string code, IUnitOfWork uow)
        {
            var alreadyExists = await uow.Tariffs.ExistsAsync(code);
            var tariff = builders[code]();

            if (!alreadyExists) uow.Tariffs.Add(tariff);
        }
    }
}
