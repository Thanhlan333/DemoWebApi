using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APINEON.Data;
using APINEON.Models;
using APINEON.DTOs;

namespace APINEON.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _context.Users
                    .Select(u => new UserDTO
                    {
                        Id = u.id,
                        FullName = u.fullname,
                        Phone = u.phone,
                        Email = u.email,
                        Role = u.role,
                        Gender = u.gender,
                        DateOfBirth = u.dateofbirth,
                        Address = u.address,
                        JoinDate = u.joindate,
                        Branch = u.branch,
                        Status = u.status,
                        SalaryId = u.salaryid
                    })
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message} - {ex.InnerException?.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var user = await _context.Users
                    .Select(u => new UserDTO
                    {
                        Id = u.id,
                        FullName = u.fullname,
                        Phone = u.phone,
                        Email = u.email,
                        Role = u.role,
                        Gender = u.gender,
                        DateOfBirth = u.dateofbirth,
                        Address = u.address,
                        JoinDate = u.joindate,
                        Branch = u.branch,
                        Status = u.status,
                        SalaryId = u.salaryid
                    })
                    .FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                {
                    return NotFound("Người dùng không tồn tại");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi server: {ex.Message} - {ex.InnerException?.Message}");
            }
        }
    }
}