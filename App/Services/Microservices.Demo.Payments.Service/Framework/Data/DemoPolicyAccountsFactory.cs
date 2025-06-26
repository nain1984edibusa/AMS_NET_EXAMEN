using Microservices.Demo.Payments.Service.Domain.Payments.Entities;

namespace Microservices.Demo.Payments.Service.Framework.Data
{
    public static class DemoPolicyAccountsFactory
    {
        public static List<PolicyAccount> DemoPolicyAccounts()
        {
            return new List<PolicyAccount>
        {
            new("POLICY_1", "231232132131", "Erick", "Arostegui Cunza"),
            new("POLICY_2", "389hfswjfrh2032r", "Bill", "Gates"),
            new("POLICY_3", "0rju130fhj20", "Stave", "Jobs")
        };
        }
    }
}
