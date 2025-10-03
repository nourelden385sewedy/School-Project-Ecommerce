using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using School_ECommerce.Data;
using School_ECommerce.Data.Models;
using School_ECommerce.DTOs;

namespace School_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly MyAppDbContext _context;
        public CustomerController(MyAppDbContext context)
        {
            _context = context;
        }


        [HttpGet] // Done
        public IActionResult GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            List<CustomerDto> customerDtos = _context.Customers
                .Select(c => new CustomerDto
                {
                    Id = c.Id,
                    Email = c.Email,
                    Orders = _context.Orders
                    .Where(x => x.CustomerId == c.Id)
                    .Select(s => new OrderDto
                    {
                        Id = s.Id,
                        OrderId = s.OrderId,
                        TotalPrice = s.TotalPrice,
                        DeliveryTime = s.DeliveryTime
                    }).ToList()
                }).ToList();

            if (customers.Count == 0)
            {
                return NotFound("There aren't any customers");
            }

            return Ok(customerDtos);
        }


        [HttpGet("{id}")] // Done
        public IActionResult GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return NotFound($"This customer with id '{id}' doesn't exist");
            }
            CustomerDto customerDto = new CustomerDto()
            {
                Id = customer.Id,
                Email = customer.Email,
                Orders = _context.Orders
                .Where(o => o.CustomerId == id)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    TotalPrice = o.TotalPrice,
                    DeliveryTime = o.DeliveryTime,
                }).ToList()
            };
            return Ok(customerDto);
        }


        [HttpGet("email/{email}")] // Done
        public IActionResult GetCustomerByEmail(string email)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Email == email);

            if (customer == null)
            {
                return NotFound($"This customer with email '{email}' doesn't exist");
            }
            CustomerDto customerDto = new CustomerDto()
            {
                Id = customer.Id,
                Email = customer.Email,
                Orders = _context.Orders
                .Where(o => o.CustomerId == customer.Id)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    TotalPrice = o.TotalPrice,
                    DeliveryTime = o.DeliveryTime,
                }).ToList()
            };
            return Ok(customerDto);
        }


        [HttpPost("create")] // Done
        public IActionResult CreateCustomer(CreateCustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest("Customer data is missing, can't create a customer");
            }
            Customer customer = new Customer()
            {
                Email = customerDto.Email,
                Password = customerDto.Password
            };

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Customer Created Successfully");
        }


        [HttpPut("update/{id}")] // Done
        public IActionResult UpdateCustomer(int id, CreateCustomerDto customerDto)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customerDto == null || customer == null)
            {
                return BadRequest("Customer data is missing, can't update a customer Or this customer doesn't exist");
            }
            customer.Email = customerDto.Email;
            customer.Password = customerDto.Password;
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok(customer);
        }


        [HttpDelete("delete/{id}")] // Done
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return NotFound($"This customer with id '{id}' doesn't exist, can't delete this customer");
            }
            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Customer Deleted Successfully");
        }


        //[HttpGet("lazy/{id}")]
        //public IActionResult GetCustomerByIdLazyLoading(int id)
        //{
        //    var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

        //    if (customer == null)
        //    {
        //        return NotFound($"This customer with id '{id}' doesn't exist");
        //    }
        //    var orders = customer.Orders;
        //    return Ok(new {customer, orders});
        //}

    }
}
