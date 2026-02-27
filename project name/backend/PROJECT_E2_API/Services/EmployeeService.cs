using Microsoft.EntityFrameworkCore;
using PROJECT_E2_API.Data;
using PROJECT_E2_API.DTOs;
using PROJECT_E2_API.Models;
using PROJECT_E2_API.Repositories;
using PROJECT_E2_API.Services;

namespace PROJECT_E2_API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly AppDbContext _context;

        public EmployeeService(IEmployeeRepository employeeRepo, AppDbContext context)
        {
            _employeeRepo = employeeRepo;
            _context = context;
        }

        
        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _employeeRepo.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                PolicyId = e.PolicyId,
                PolicyName = e.Policy.Name
            }).ToList();
        }

       
        public async Task<(bool success, string message)> CreateAsync(CreateEmployeeDto dto)
        {
            //  required fields
            if (string.IsNullOrWhiteSpace(dto.FirstName))
                return (false, "FirstName is required.");
            if (string.IsNullOrWhiteSpace(dto.LastName))
                return (false, "LastName is required.");
            if (string.IsNullOrWhiteSpace(dto.Email))
                return (false, "Email is required.");

            // policy there?
            var policyExists = await _context.Policies.AnyAsync(p => p.Id == dto.PolicyId);
            if (!policyExists)
                return (false, "PolicyId does not exist.");

            // email is taken?
            var emailExists = await _employeeRepo.GetByEmailAsync(dto.Email);
            if (emailExists != null)
                return (false, "Email already exists.");

            
            var employee = new Employee
            {
                PolicyId = dto.PolicyId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                IsActive = true
            };

            await _employeeRepo.AddAsync(employee);
            await _employeeRepo.SaveAsync();
            return (true, "Employee created successfully.");
        }
    }
}