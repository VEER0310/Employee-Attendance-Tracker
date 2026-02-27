using Microsoft.AspNetCore.Mvc;
using PROJECT_E2_API.Services;

namespace PROJECT_E2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportsController(IReportService service)
        {
            _service = service;
        }

        // GET /api/reports/daily-attendance?date=2026-02-24
        [HttpGet("daily-attendance")]
        public async Task<IActionResult> GetDailyAttendance([FromQuery] DateTime date)
        {
            var report = await _service.GetDailyReportAsync(date);
            return Ok(report);
        }
    }
}