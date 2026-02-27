using PROJECT_E2_API.DTOs;

namespace PROJECT_E2_API.Services
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDto>> GetAllAsync();
        Task<(bool success, string message)> CreateAsync(CreateEmployeeDto dto);
    }
}