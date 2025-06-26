using Marten;
using Microservices.Demo.Payments.Service.Domain.Payments;
using Microservices.Demo.Payments.Service.Domain.Payments.Entities;
using Microservices.Infrastructure.Persistences.EF.NonRelational.Marten.Repositories;

namespace Microservices.Demo.Payments.Service.Infrastructure.Persistence.Marten.PostgreSQL.Repositories
{
    public class PolicyAccountRepository : MartenRepository<PolicyAccount, IDocumentSession>, IPolicyAccountRepository
    {
        public PolicyAccountRepository(IDocumentSession session) : base(session) { }
        public async Task<PolicyAccount?> FindByNumber(string policyNumber)
        {
            return await _session.Query<PolicyAccount>().FirstOrDefaultAsync(p => p.PolicyNumber == policyNumber);
        }

        public async Task<bool> ExistsWithPolicyNumber(string policyNumber)
        {
            return await _session.Query<PolicyAccount>().AnyAsync(p => p.PolicyNumber == policyNumber);
        }
    }
}
