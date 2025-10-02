using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data;
using School_ECommerce.DTOs;

namespace School_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TryController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        public TryController(MyAppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var orders = _context.Orders.SelectMany(x => x.Products).Select(p => p.Name).ToList();
        //    return Ok(orders);
        //}

        //[HttpGet("s1")]
        //public IActionResult Index1()
        //{
        //    var orders = _context.Orders.Where(p => p.Products.Count > 2).Select(p => p.Products.Select(p => p.Name)).ToList();
        //    return Ok(orders);
        //}

        //[HttpGet("s2")]
        //public IActionResult Index2()
        //{
        //    var orders = _context.Orders
        //        .Include(p => p.Products.Where(p => p.Price > 100))
        //        .Select(o => new OrderWithProductsDto
        //        {
        //            Id = o.Id,
        //            TotalPrice = o.TotalPrice,
        //            DeliveryTime = o.DeliveryTime,
        //            Products = o.Products.Select(l => new ProductDto
        //            {
        //                Id = l.Id,
        //                Name = l.Name,
        //                Price = l.Price,
        //            }).ToList()
        //        })
        //        .ToList();
        //    return Ok(orders);
        //}

        //[HttpGet("s3")]
        //public IActionResult Index3()
        //{
        //    var orders = _context.Orders
        //        .Where(p => p.Products.Count > 2)
        //        .Include(p => p.Products.Where(p => p.Price > 100)).ToList();

        //    var o = _context.Orders
        //        .Include(p => p.Products.Where(c => c.Price >100))
        //        .Where(o => o.Products.Count >= 2 && o.Products.Any(l => l.Price > 100)).ToList();  
        //    return Ok(o);
        //}

        //[HttpGet("s4/{id}")]
        //public IActionResult Index4(int id)
        //{
        //    var order = _context.Customers.Include(c => c.Orders.OrderBy(o => o.DeliveryTime)).FirstOrDefault(v => v.Id == id);
        //    //var order = _context.Customers.Select(c => c.Orders.OrderBy(o => o.DeliveryTime).LastOrDefault()).FirstOrDefault(v => v.Id == id);
        //    return Ok(order);
        //}

        //[HttpGet("s5/")]
        //public IActionResult Index5()
        //{
        //    var order = _context.Orders
        //        .Where(o => o.Products.Count > 2)
        //        .OrderBy(i => i.DeliveryTime).ToList();
        //    return Ok(order);
        //}

        [HttpGet("s6")]
        public IActionResult Index6()
        {
            var products = _context.Products
                .Where(p =>p.Price > 100)
                .OrderBy(p => p.Name)
                .ToList();
            return Ok(products);
        }

        //[HttpGet("s7")]
        //public IActionResult Index7()
        //{
        //    var products = _context.Orders
        //        .Where(p => p.)
        //    return Ok(products);
        //}


    }
}
