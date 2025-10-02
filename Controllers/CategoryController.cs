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


        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var categories = _context.Categories;
        //}
    }
}
