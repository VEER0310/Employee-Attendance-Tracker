using PROJECT_E2_API.DTOs;
using PROJECT_E2_API.Models;
using PROJECT_E2_API.Repositories;

namespace PROJECT_E2_API.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepo;
        private readonly IEmployeeRepository _employeeRepo;

        public AttendanceService(IAttendanceRepository attendanceRepo, IEmployeeRepository employeeRepo)
        {
            _attendanceRepo = attendanceRepo;
            _employeeRepo = employeeRepo;
        }

        public async Task<(bool success, int statusCode, string message)> MarkAttendanceAsync(CreateAttendanceDto dto)
        {
            //  hours 0-24
            if (dto.HoursWorked < 0 || dto.HoursWorked > 24)
                return (false, 400, "HoursWorked must be between 0 and 24.");

            // attendance already there for same date?
            var existing = await _attendanceRepo.GetByEmployeeAndDateAsync(dto.EmployeeId, dto.AttendanceDate.Date);
            if (existing != null)
                return (false, 409, "Attendance already marked for this employee on this date.");

            
            var employee = await _employeeRepo.GetByIdAsync(dto.EmployeeId);
            if (employee == null)
                return (false, 404, "Employee not found.");

            
            string finalStatus;

            if (dto.Status == "Absent")
            {

                // If absent, hours must be 0
                finalStatus = "Absent";
                dto.HoursWorked = 0;  
            }

            else if (dto.Status == "Present")
            {

                // comparing working and min hours 
                if (dto.HoursWorked < employee.Policy.MinDailyHours)
                    finalStatus = "ShortHours";  
                else
                    finalStatus = "Present";     
            }

            else
            {
                return (false, 400, "Status must be Present or Absent.");
            }

            
            var record = new AttendanceRecord
            {
                EmployeeId = dto.EmployeeId,
                AttendanceDate = dto.AttendanceDate.Date,
                Status = finalStatus,
                HoursWorked = dto.HoursWorked
            };

            await _attendanceRepo.AddAsync(record);
            await _attendanceRepo.SaveAsync();
            return (true, 200, "Attendance marked successfully.");
        }
    }
}