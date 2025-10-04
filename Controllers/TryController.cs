using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data;
using School_ECommerce.Data.Models;
using School_ECommerce.DTOs;
using System.Linq;

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



        [HttpGet("1")]
        public IActionResult Index1()
        {
            var orders = _context.Orders.Where(o => o.TotalPrice > 1000).ToList();
            return Ok(orders);
        }


        [HttpGet("2")]
        public IActionResult Index2()
        {
            var products = _context.Products.Where(p => p.Amount == 0).ToList();
            return Ok(products);
        }

        [HttpGet("3")]
        public IActionResult Index3()
        {
            var date = new DateOnly(2025, 10, 06);
            var orders = _context.Orders.Where(o => o.DeliveryTime ==  date).ToList();
            return Ok(orders);
        }


        [HttpGet("4")]
        public IActionResult Index4()
        {
            var emails = _context.Customers.Select(e => e.Email).ToList();
            return Ok(emails);
        }


        [HttpGet("5")]
        public IActionResult Index5()
        {
            var products = _context.Orders.SelectMany(o => o.OrderItems).ToList();

            var pr = _context.Products.Where(p => p.OrderItems.Count() > 0).ToList();
            return Ok(pr);
        }


        [HttpGet("6")]
        public IActionResult Index6()
        {

            var pr = _context.Products.Where(p => p.OrderItems.Count() > 0).Select(p => p.Name).ToList();

            var pp = _context.OrderItems.Select(p => p.Product.Name).ToList();

            var products = _context.OrderItems.GroupBy(o => o.Order)
                .Select(i => new
                {
                    i.Key.Id,
                    i.Key.OrderId,
                    OrderItems = i.Select(io => io.Product.Name).ToList()
                }).ToList();

            return Ok(products);
        }


        [HttpGet("7")]
        public IActionResult Index7()
        {
            var orders = _context.Orders.Where(o => o.OrderItems.Count() >= 2)
                .Select(io => new
                {
                    io.Id,
                    io.OrderId,
                    io.DeliveryTime,
                    products = io.OrderItems.Select(p => p.Product.Name).ToList()
                })
                .ToList();
            return Ok(orders);
        }


        [HttpGet("8")]
        public IActionResult Index8()
        {
            var orders = _context.Orders
                .Select(io => new
                {
                    io.Id,
                    io.OrderId,
                    io.DeliveryTime,
                    products = io.OrderItems.Where(o => o.PriceAtOrder > 100).Select(p => p.Product).ToList()
                })
                .ToList();
            return Ok(orders);
        }


        [HttpGet("9")]
        public IActionResult Index9()
        {
            var orders = _context.Orders.Where(o => o.OrderItems.Count() >= 2)
                .Select(io => new
                {
                    io.Id,
                    io.OrderId,
                    io.DeliveryTime,
                    products = io.OrderItems.Where(p => p.PriceAtOrder > 100).Select(p => p.Product.Name).ToList()
                })
                .ToList();
            return Ok(orders);
        }


        [HttpGet("10/{id}")]
        public IActionResult Index(int id)
        {
            var order = _context.Customers.Select(o => o.Orders.FirstOrDefault()).FirstOrDefault(o => o.Id == id);

            var o = _context.Orders
                .Where(o => o.CustomerId == id)
                .OrderBy(o => o.DeliveryTime)
                .FirstOrDefault();
            return Ok(o);
        }


        [HttpGet("11")]
        public IActionResult Index11()
        {
            var orders = _context.Orders.OrderBy(o => o.DeliveryTime)
                .Select(o => new
                {
                    o.Id,
                    o.OrderId,
                    o.DeliveryTime,
                    products = o.OrderItems.Select(i => i.Product.Name).ToList()
                })
                .ToList();
            return Ok(orders);
        }


        [HttpGet("12")]
        public IActionResult Index12()
        {
            var orders = _context.Orders
                .Select(o => new
                {
                    o.Id,
                    o.OrderId,
                    o.DeliveryTime,
                    products = o.OrderItems.OrderBy(o => o.PriceAtOrder).Select(i => i.Product).ToList()
                })
                .ToList();
            return Ok(orders);
        }


        [HttpGet("13")]
        public IActionResult Index13()
        {
            var orders = _context.Orders
                .Where(o => o.OrderItems.Count() >= 2)
                .OrderBy(o => o.DeliveryTime)
                .ToList();
            return Ok(orders);
        }


        [HttpGet("14")]
        public IActionResult Index14()
        {
            var products = _context.Products
                .Where(p => p.Price > 100)
                .OrderBy(p => p.Name)
                .Select(p => p.Name)
                .ToList();
                
            return Ok(products);
        }


        [HttpGet("15")]
        public IActionResult Index15()
        {
            var orders = _context.Orders
                .Where(p => p.OrderItems.Count() >= 2)
                .OrderBy (p => p.TotalPrice)
                .Select(o => new
                {
                    o.OrderId,
                    products = o.OrderItems.Select(i => new {productName = i.Product.Name}).ToList(),
                    Count_of_products = o.OrderItems.Count()
                })
                .ToList();
                
            return Ok(orders);
        }


        [HttpGet("19")]
        public IActionResult Index19()
        {
            var count = _context.Customers.Count();
                
            return Ok(count);
        }


        [HttpGet("20")]
        public IActionResult Index20()
        {
            var total = _context.Orders.Sum(o => o.TotalPrice);
                
            return Ok(new {Total_Sales = total});
        }


        [HttpGet("21")]
        public IActionResult Index21()
        {
            var average = _context.Orders.Average(o => o.TotalPrice);
                
            return Ok(new {average_Sales = average });
        }


        [HttpGet("22")]
        public IActionResult Index22()
        {
            var highest = _context.Orders.Max(o => o.TotalPrice);
                
            return Ok(new {Highest_order_price = highest });
        }


        [HttpGet("23")]
        public IActionResult Index23()
        {
            var lower = _context.Orders.Min(o => o.TotalPrice);

            return Ok(new { Lower_order_price = lower });
        }


        [HttpGet("24")]
        public IActionResult Index24()
        {
            var any = _context.Orders.Any(o => o.TotalPrice > 5000);
                
            return Ok(new { order_above_5000 = any });
        }


        [HttpGet("25")]
        public IActionResult Index25()
        {
            var all = _context.Products.All(o => o.Price > 0);
                
            return Ok(new { price_over_0 = all });
        }


        [HttpGet("26/{email}")]
        public IActionResult Index26(string email)
        {
            var any = _context.Customers.Any(o => o.Email  == email);
                
            return Ok(new { email_exists = any });
        }


        [HttpGet("27")]
        public IActionResult Index27()
        {
            var productName = _context.Products
                .Select(p => p.Name)
                .Distinct().ToList();
                
            return Ok(new { productName });
        }


        [HttpGet("28")]
        public IActionResult Index28()
        {
            var cairo = _context.CustomerProfiles
                .Where(cu => cu.Address == "Cairo")
                .Select(c => c.Name)
                .ToList();

            var giza = _context.CustomerProfiles
                .Where(cu => cu.Address == "Giza")
                .Select(c => c.Name)
                .ToList();

            var un = cairo.Union(giza).ToList();

            var cus = _context.CustomerProfiles
                .Where(cu => cu.Address == "Cairo" || cu.Address == "Giza")
                .Select(c => c.Name)
                .ToList();

            return Ok(cus);
        }


        [HttpGet("29")]
        public IActionResult Index29()
        {
            var cairo = _context.CustomerProfiles
                .Where(cu => cu.Address == "Cairo")
                .Select(c => c.CustomerId)
                .ToList();

            var orders = _context.Orders
                .Where(o => o.TotalPrice > 1000)
                .Select(c => c.CustomerId)
                .ToList();

            var inter = cairo.Intersect(orders);

            var cs = new List<CustomerProfile>();
            foreach (var cusId in inter)
            {
                var c = _context.CustomerProfiles.FirstOrDefault(c => c.Id == cusId);
                cs.Add(c);
            }

            return Ok(cs);
        }

        [HttpGet("30")]
        public IActionResult Index30()
        {
            var cairo = _context.CustomerProfiles
                .Where(cu => cu.Address == "Cairo")
                .Select(c => c.CustomerId)
                .ToList();

            var orders = _context.Customers
                .Where(c => c.Orders.Count() == 0)
                .Select(c => c.Id)
                .ToList();

            var ex = cairo.Except(orders);



            return Ok(ex);
            
        }


    }
}
