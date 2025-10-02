using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data;
using School_ECommerce.Data.Models;
using School_ECommerce.DTOs;

namespace School_ECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly MyAppDbContext _context;
        public OrderController(MyAppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _context.Orders.Include(o => o.Customer)
                .Select(o => new OrderDto
                {
                    Id = o.Id,
                    OrderId = o.OrderId,
                    TotalPrice = o.TotalPrice,
                    DeliveryTime = o.DeliveryTime,
                    Customerdto = new CustomerOrderDto
                    {
                        Id = o.Customer.Id,
                        Email = o.Customer.Email,
                    }
                })
                .ToList();
            if (orders.Count == 0)
            {
                return NotFound("There aren't any orders right now!!");
            }
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var order = _context.Orders
                .Select(o => new OrderDto
                {
                    Id =o.Id,
                    OrderId = o.OrderId,
                    TotalPrice = o.TotalPrice,
                    DeliveryTime = o.DeliveryTime,
                    Customerdto = new CustomerOrderDto 
                    {
                        Id =o.Customer.Id,
                        Email = o.Customer.Email
                    }
                })
                .FirstOrDefault(o => o.Id == id);
            if (order == null)
            {
                return NotFound("There aren't any orders right now!!");
            }
            return Ok(order);
        }

        [HttpPost("create")]
        public IActionResult CreateOrder(CreateOrder orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("there is something went wrong");
            }
            Order order = new Order()
            {
                OrderId = orderDto.OrderId,
                TotalPrice = orderDto.TotalPrice,
                CustomerId = orderDto.CustomerId
            };
            _context.Add(order);
            _context.SaveChanges();
            return Ok(new { message = "order Created successfully", orderDto });
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateOrder(int id, CreateOrder orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("there is something went wrong");
            }
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            order.OrderId = orderDto.OrderId;
            order.TotalPrice = orderDto.TotalPrice;
            _context.Update(order);
            _context.SaveChanges();
            return Ok(new { message = "order Updated successfully",orderId = id, orderDto });
        }


        [HttpGet("customer-id/{id}")]
        public IActionResult GetOrderByCustomerId(int id)
        {

            //var order = _context.Orders
            //    .Select(o => new OrderDto
            //    {
            //        Id = o.Id,
            //        OrderId = o.OrderId,
            //        TotalPrice = o.TotalPrice,
            //        DeliveryTime = o.DeliveryTime,
            //        Customerdto = new CustomerOrderDto
            //        {
            //            Id = o.Customer.Id,
            //            Email = o.Customer.Email
            //        }
            //    })
            //    .FirstOrDefault(o => o.Id == id);

            var order = _context.Customers
                .Select(oi => new CustomerDto
                {
                    Id = oi.Id,
                    Email = oi.Email,
                    Orders = _context.Orders
                    .Where(o => o.CustomerId == id)
                    .Select(oo => new OrderDto
                    {
                        Id = oo.Id,
                        OrderId = oo.OrderId,
                        TotalPrice = oo.TotalPrice,
                        DeliveryTime = oo.DeliveryTime
                    }).ToList()
                }).FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                return NotFound("There aren't any orders right now!!");
            }
            return Ok(order);
        }


        [HttpGet("custom/")]
        public IActionResult Custom()
        {

            return Ok();
        }
    }
}
