using Microsoft.EntityFrameworkCore;
using PROJECT_E2_API.Data;
using PROJECT_E2_API.Models;

namespace PROJECT_E2_API.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

 
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Include(e => e.Policy)  // policy table jode join
                .ToListAsync();
        }


        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.Policy)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        // Email 6 k nai?
        public async Task<Employee?> GetByEmailAsync(string email)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Email == email);
        }


        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}