using PROJECT_E2_API.DTOs;

namespace PROJECT_E2_API.Services
{
    public interface IAttendanceService
    {
        Task<(bool success, int statusCode, string message)> MarkAttendanceAsync(CreateAttendanceDto dto);
    }
}