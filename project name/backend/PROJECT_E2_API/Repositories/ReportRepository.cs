using PROJECT_E2_API.Repositories;
using Microsoft.EntityFrameworkCore;
using PROJECT_E2_API.Data;
using PROJECT_E2_API.DTOs;

namespace PROJECT_E2_API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

       

        // joining tables: ARecords * Employees * Policies
        public async Task<List<DailyAttendanceReportDto>> GetDailyAttendanceAsync(DateTime date)
        {
            var result = await _context.AttendanceRecords
                .Where(a => a.AttendanceDate == date)          //  date nu filtering
                .Include(a => a.Employee)                       // joining Employees
                .ThenInclude(e => e.Policy)                    // joining Policies
                .Select(a => new DailyAttendanceReportDto
                {
                    EmployeeId = a.EmployeeId,
                    FullName = a.Employee.FirstName + " " + a.Employee.LastName,
                    PolicyName = a.Employee.Policy.Name,
                    MinDailyHours = a.Employee.Policy.MinDailyHours,
                    AttendanceDate = a.AttendanceDate,
                    Status = a.Status,
                    HoursWorked = a.HoursWorked,
                    
                    DailyFlag = a.Status == "ShortHours" ? "PolicyViolation" : "OK"
                })
                .ToListAsync();

            return result;
        }
    }
}