using Microservices.Demo.Reports.Service.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.Demo.Reports.Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReportAsync()
        {
            var result = await _reportService.GetPolicyReportsAsync();
            return Ok(result);
        }
    }
}
