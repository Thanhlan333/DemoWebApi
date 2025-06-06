using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APINEON.Data;
using APINEON.Models;

namespace APINEON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalariesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SalariesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Salarie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetSalaries()
        {
            try
            {
                var salaries = await _context.Salaries.ToListAsync();
                return Ok(salaries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message} - {ex.InnerException?.Message}");
            }
        }

        // GET: api/Salaries/5
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetSalary(int id)
        {
            try
            {
                var salary = await _context.Salaries
                    .FirstOrDefaultAsync(s => s.id == id);

                if (salary == null)
                {
                    return NotFound("Không tìm thấy mức lương.");
                }

                return Ok(salary);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message} - {ex.InnerException?.Message}");
            }
        }
    }
}