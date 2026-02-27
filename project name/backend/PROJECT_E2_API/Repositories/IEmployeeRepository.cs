
using PROJECT_E2_API.Models;

namespace PROJECT_E2_API.Repositories
{
   
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        Task<Employee?> GetByEmailAsync(string email);
        Task AddAsync(Employee employee);
        Task SaveAsync();
    }
}