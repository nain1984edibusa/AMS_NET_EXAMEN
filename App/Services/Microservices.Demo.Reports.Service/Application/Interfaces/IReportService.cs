using Microservices.Demo.Reports.Service.Application.Dtos;

namespace Microservices.Demo.Reports.Service.Application.Interfaces
{
    public interface IReportService
    {
        Task<List<PolicyReportDto>> GetPolicyReportsAsync();
    }
}
