using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data;
using School_ECommerce.Data.Models;
using School_ECommerce.DTOs;
using System.Reflection.Metadata.Ecma335;

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


        [HttpGet] // Done
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
                    },
                })
                .ToList();
            if (orders.Count == 0)
            {
                return NotFound("There aren't any orders right now!!");
            }
            return Ok(orders);
        }


        [HttpGet("{id}")] // Done
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
                return NotFound($"Sorry, There isn't any order with id '{id}' !!");
            }
            return Ok(order);
        }


        [HttpPost("create")] // Done
        public IActionResult CreateOrder(CreateOrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("there is something went wrong");
            }
            Order order = new Order()
            {
                OrderId = orderDto.OrderId,
                TotalPrice = orderDto.TotalPrice,
                CustomerId = orderDto.CustomerId,
            };


            foreach (var item in orderDto.OrderItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product == null) 
                    return NotFound($"Product with ID '{item.ProductId}' not found.");

                if (product.Amount < item.Amount)
                    return BadRequest($"Not enough stock for product '{product.Id}'");

                var orderitem = new OrderItem()
                {
                    ProductId = product.Id,
                    Amount = item.Amount,
                    PriceAtOrder = product.Price
                };

                product.Amount -= item.Amount;

                orderDto.TotalPrice += (product.Price * (item.Amount ?? 1));

                order.OrderItems.Add(orderitem);
            }


            order.TotalPrice = orderDto.TotalPrice;


            _context.Add(order);
            _context.SaveChanges();
            return Ok(new { message = "order Created successfully", orderDto });
        }


        [HttpPut("update/{id}")] // Done
        public IActionResult UpdateOrder(int id, UpdateOrderDto orderDto)
        {
            var order = _context.Orders.Include(o => o.OrderItems).FirstOrDefault(o => o.Id == id);
            if (order == null)
                return NotFound($"Error, Order With ID '{id}' not found");

            if (orderDto == null)
                return BadRequest("there is something went wrong");

            order.TotalPrice = 0;

            foreach (var oldItem in order.OrderItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == oldItem.ProductId);
                if (product != null)
                {
                    product.Amount += oldItem.Amount ?? 0; // restore stock
                }
            }
            order.OrderItems.Clear();


            foreach (var item in orderDto.OrderItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == item.ProductId);

                if (product == null)
                    return NotFound($"Product with ID '{item.ProductId}' not found.");

                if (product.Amount < item.Amount)
                    return BadRequest($"Not enough stock for product '{product.Id}'");

                var orderItem = new OrderItem
                {
                    ProductId = product.Id,
                    Amount = item.Amount,
                    PriceAtOrder = product.Price
                };

                // decrease stock
                product.Amount -= item.Amount;

                // recalc total
                order.TotalPrice += product.Price * (item.Amount ?? 1);

                order.OrderItems.Add(orderItem);
            }



            _context.Update(order);
            _context.SaveChanges();
            return Ok(new { message = "Order updated successfully",orderId = id, orderDto });
        }


        [HttpGet("customer-id/{id}")] // Done
        public IActionResult GetOrderByCustomerId(int id)
        {

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


    }
}
