using PROJECT_E2_API.DTOs;

namespace PROJECT_E2_API.Services
{
    public interface IReportService
    {
        Task<List<DailyAttendanceReportDto>> GetDailyReportAsync(DateTime date);
    }
}