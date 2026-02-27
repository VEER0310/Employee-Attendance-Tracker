using PROJECT_E2_API.Repositories;
using PROJECT_E2_API.DTOs;

namespace PROJECT_E2_API.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepo;

        public ReportService(IReportRepository reportRepo)
        {
            _reportRepo = reportRepo;
        }

        public async Task<List<DailyAttendanceReportDto>> GetDailyReportAsync(DateTime date)
        {
            // daily flag 
            return await _reportRepo.GetDailyAttendanceAsync(date);
        }
    }
}