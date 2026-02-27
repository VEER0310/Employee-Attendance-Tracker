using Microsoft.EntityFrameworkCore;
using PROJECT_E2_API.Data;
using PROJECT_E2_API.Models;

namespace PROJECT_E2_API.Repositories
{


    public class AttendanceRepository : IAttendanceRepository
    {


        private readonly AppDbContext _context;


        public AttendanceRepository(AppDbContext context)
        {
            _context = context;
        }


        
        // duplicate na hoy ena maate find attendance exist 6 k nai 
        public async Task<AttendanceRecord?> GetByEmployeeAndDateAsync(int employeeId, DateTime date)
        {
            return await _context.AttendanceRecords
                .FirstOrDefaultAsync(a => a.EmployeeId == employeeId && a.AttendanceDate == date);
        }


        public async Task AddAsync(AttendanceRecord record)
        {
            await _context.AttendanceRecords.AddAsync(record);
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}