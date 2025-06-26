using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;
using Microservices.SharedKernel.Domain.Interfaces;
using System.Threading.Tasks;

namespace Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces;

public interface ITariffRepository : IRepository<Tariff>
{
    Task<Tariff> this[string code] { get; }
    Task<Tariff> WithCode(string code);

    void Add(Tariff tariff);

    Task<bool> ExistsAsync(string code);
}