using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School_ECommerce.Data;
using School_ECommerce.Data.Models;
using School_ECommerce.DTOs;

namespace School_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        public ProductController(MyAppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Amount = p.Amount,
                    Category = p.Category.Name,
                }).ToList();
            if (products.Count == 0)
            {
                return NotFound("There aren't any products right now");
            }
            return Ok(products);
        }


        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            var product = _context.Products
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Amount = p.Amount,
                    Category = p.Category.Name,
                }).FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound("There aren't any products right now");
            }
            return Ok(product);
        }


        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto pr)
        {
            if (pr == null)
            {
                return NotFound("there is a missing data or something went wrong");
            }
            Product p = new Product()
            {
                Name = pr.Name,
                Price = pr.Price,
                Amount = pr.Amount,
                CategoryId = pr.CategoryId,
            };
            _context.Products.Add(p);
            _context.SaveChanges();
            return Ok(pr);
        }


        [HttpPut("update/{id}")]
        public IActionResult UpdateProduct(int id, CreateProductDto pr)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (pr == null)
            {
                return NotFound("there is a missing data or something went wrong");
            }

            product.Name = pr.Name;
            product.Price = pr.Price;
            product.Amount = pr.Amount;
            product.CategoryId = pr.CategoryId;
            
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok(pr);
        }


        [HttpGet("custom/")]
        public IActionResult Custom()
        {
            
            return Ok();
        }
    }
}
