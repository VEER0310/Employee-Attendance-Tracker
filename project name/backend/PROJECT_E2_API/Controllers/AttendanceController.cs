using Microsoft.AspNetCore.Mvc;
using PROJECT_E2_API.DTOs;
using PROJECT_E2_API.Services;

namespace PROJECT_E2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;

        public AttendanceController(IAttendanceService service)
        {
            _service = service;
        }

        // POST /api/attendance 
        [HttpPost]
        public async Task<IActionResult> Mark([FromBody] CreateAttendanceDto dto)
        {
            var (success, statusCode, message) = await _service.MarkAttendanceAsync(dto);

            if (!success)
            {
                
                return statusCode switch
                {
                    409 => Conflict(new { message }),         // duplicate
                    404 => NotFound(new { message }),         // employee not found
                    _ => BadRequest(new { message })          // validation error
                };
            }

            return Ok(new { message });
        }
    }
}