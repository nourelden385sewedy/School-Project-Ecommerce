using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_ECommerce.Data;

namespace School_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        public CategoryController(MyAppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories.ToList();

            if (categories == null)
            {
                return NotFound("There is no Categories right now");
            }

            return Ok(categories);
        }
    }
}
