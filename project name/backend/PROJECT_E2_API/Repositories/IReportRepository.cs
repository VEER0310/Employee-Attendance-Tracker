using PROJECT_E2_API.DTOs;

namespace PROJECT_E2_API.Repositories
{
    public interface IReportRepository
    {
        Task<List<DailyAttendanceReportDto>> GetDailyAttendanceAsync(DateTime date);
    }
}