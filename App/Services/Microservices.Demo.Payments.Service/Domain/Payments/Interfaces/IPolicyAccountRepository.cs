using Microservices.Demo.Payments.Service.Domain.Payments.Entities;
using Microservices.SharedKernel.Domain.Interfaces;

namespace Microservices.Demo.Payments.Service.Domain.Payments
{
    public interface IPolicyAccountRepository: IRepository<PolicyAccount>
    {
        Task<bool> ExistsWithPolicyNumber(string policyNumber);
        Task<PolicyAccount?> FindByNumber(string policyNumber);
    }
}