using PROJECT_E2_API.Models;

namespace PROJECT_E2_API.Repositories
{
    public interface IAttendanceRepository
    {
        // attandance mark thayeli 6 employee a date par
        Task<AttendanceRecord?> GetByEmployeeAndDateAsync(int employeeId, DateTime date);
        
        Task AddAsync(AttendanceRecord record);
        
        Task SaveAsync();
    }
}