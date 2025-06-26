using Microservices.Demo.Reports.Service.Application.Dtos;
using Microservices.Demo.Reports.Service.Application.Interfaces;

namespace Microservices.Demo.Reports.Service.Application.Services
{
    public class ReportService : IReportService
    {

        private readonly IPolicyClient _policyClient;
        private readonly IProductClient _productClient;

        public ReportService(IPolicyClient policyClient, IProductClient productClient)
        {
            _policyClient = policyClient;
            _productClient = productClient;
        }

        public async Task<List<PolicyReportDto>> GetPolicyReportsAsync()
        {
            var policies = await _policyClient.GetPoliciesAsync();
            var report = new List<PolicyReportDto>();

            foreach (var policy in policies)
            {
                try
                {
                    var policeVersion = await _policyClient.GetPolicyVersionAsync(policy.Id);
                    if (policeVersion?.PolicyHolder == null)
                        continue;

                    var product = await _productClient.GetProductByCodeAsync(policy.ProductCode);
                    if (product == null)
                        continue;

                    report.Add(new PolicyReportDto
                    {
                        PolicyNumber = policy.Number,
                        ProductCode = policy.ProductCode,
                        DescripcionCode = product.description,
                        HolderFirstName = policeVersion.PolicyHolder.HolderFirstName,
                        HolderLastName = policeVersion.PolicyHolder.HolderLastName,
                        HolderStreet = policeVersion.PolicyHolder.HolderStreet,
                        HolderCountry = policeVersion.PolicyHolder.HolderCountry,
                        HolderCity = policeVersion.PolicyHolder.HolderCity,
                        HolderZipCode = policeVersion.PolicyHolder.HolderZipCode
                    });
                }
                catch (Exception ex)
                {
                    // Puedes registrar el error si lo deseas, pero continuar con las demás iteraciones
                    Console.WriteLine($"Error procesando póliza {policy.Number}: {ex.Message}");
                }
            }

            return report;
        }
    }
}
