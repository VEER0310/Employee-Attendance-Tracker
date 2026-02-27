using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJECT_E2_API.Data;

namespace PROJECT_E2_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PoliciesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PoliciesController(AppDbContext context)
        {
            _context = context;
        }

        // GET /api/policies - get all policies for dropdown
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var policies = await _context.Policies.ToListAsync();
            return Ok(policies);
        }
    }
}