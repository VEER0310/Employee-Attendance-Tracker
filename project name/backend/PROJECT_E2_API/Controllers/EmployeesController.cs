using Microsoft.AspNetCore.Mvc;
using PROJECT_E2_API.DTOs;
using PROJECT_E2_API.Services;

namespace PROJECT_E2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        // GET /api/employees 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _service.GetAllAsync();
            return Ok(employees);
        }

        // POST /api/employees 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            var (success, message) = await _service.CreateAsync(dto);
            if (!success)
                return BadRequest(new { message });  // 400 with error message

            return Ok(new { message });
        }
    }
}