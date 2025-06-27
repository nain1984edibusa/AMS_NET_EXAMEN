using Microservices.Demo.Reports.Service.Application.Dtos;
using Microservices.Demo.Reports.Service.Application.Interfaces;

namespace Microservices.Demo.Reports.Service.Application.Service
{
    public class ReportService : IReportService
    {
        public async Task<IEnumerable<PolicyReportDto>> GetPolicyReportsAsync()
        {
            // Simulación de datos
            return await Task.FromResult(new List<PolicyReportDto>
            {
                new PolicyReportDto
                {
                    PolicyNumber = "POL-12345",
                    ProductCode = "AUTO",
                },
                new PolicyReportDto
                {
                    PolicyNumber = "POL-54321",
                    ProductCode = "HOME",
                }
            });
        }
    }
}
