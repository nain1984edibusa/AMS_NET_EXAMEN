using Microservices.Demo.Policies.Service.Domain.Policies.Entities;
using Microservices.Demo.Policies.Service.Domain.Policies.Interfaces;
using Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Contexts;
using Microservices.Infrastructure.Persistences.EF.Relational.Generic;
using Microsoft.EntityFrameworkCore;

namespace Microservices.Demo.Policies.Service.Infrastructure.Persistence.EF.MySQL.Policies.Repositories
{
    public class PolicyRepository : Repository<Policy, PoliciesDbContext>, IPolicyRepository
    {
        public PolicyRepository(PoliciesDbContext context) : base(context) { }

        public async Task<List<Policy>> FindAllPolicies()
        {
            return await _context
                .Policies
                //.Include(c => c.Covers)
                //.Include("Questions.Choices")
                //.Where(p => p.Status == ProductStatus.Active)
                .ToListAsync();
        }

        public async Task<Policy> WithNumber(string number)
        {
            return await _context.Policies
                            .Include(p => p.Versions)
                            .FirstOrDefaultAsync(p => p.Number == number);
        }

        public async Task<PolicyVersion> WithPolicyId(string number)
        {
            return await _context
                .PolicyVersions
                .Include(p => p.PolicyHolder)
                .FirstOrDefaultAsync(p => p.Policy.Id.ToString() == number);
        }
    }
}
