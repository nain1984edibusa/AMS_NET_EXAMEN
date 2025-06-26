using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts;
using Microservices.Infrastructure.Persistences.EF.Relational.Generic;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Repositories
{
    public class OfferRepository : Repository<Offer, PoliciesDbContext>, IOfferRepository
    {
        public OfferRepository(PoliciesDbContext context) : base(context) { }
               
        public async Task<Offer> WithNumber(string number)
        {
            return await _context.Offers.FirstOrDefaultAsync(o => o.Number == number);
        }
    }
}
