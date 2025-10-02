using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data;

namespace School_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerProfileController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        public CustomerProfileController(MyAppDbContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public IActionResult GetProfileById(int id)
        {
            var profile = _context.CustomerProfiles.Include(c => c.Customer).FirstOrDefault(p => p.Id == id);
            if (profile == null)
            {
                return NotFound($"Customer profile with id '{id}' not found");
            }
            return Ok(profile);
        }
    }
}
