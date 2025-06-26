using System.Linq.Expressions;
using System.Threading.Tasks;
using Marten;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Entities;
using Microservices.Demo.Pricing.Service.Domain.Pricing.Interfaces;
using Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories;
using Microservices.SharedKernel.Domain.Specifications;

namespace Microservices.Demo.Pricing.Service.Infrastructure.Persistence.Marten.PostgreSQL.Repositories;

public class TariffRepository : MartenRepository<Tariff,IDocumentSession>, ITariffRepository
{    
    public TariffRepository(IDocumentSession session)
        : base(session)
    {     
    }     
        
    public void Add(Tariff tariff)
    {
        _session.Insert(tariff);
    }
    public async Task<bool> ExistsAsync(string code)
    {
        return await _session.Query<Tariff>().AnyAsync(t => t.Code == code);
    }
    public async Task<Tariff> WithCode(string code)
    {
        return await _session.Query<Tariff>().FirstOrDefaultAsync(t => t.Code == code);
    }
    public Task<Tariff> this[string code] => WithCode(code);

}