using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using School_ECommerce.Data;
using School_ECommerce.Data.Models;
using School_ECommerce.DTOs;

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
            var profile = _context.CustomerProfiles.FirstOrDefault(p => p.Id == id);
            if (profile == null)
            {
                return NotFound($"Sorry, Profile with id '{id}' not found");
            }
            return Ok(profile);
        }

        [HttpPost("create")]
        public IActionResult CreateCustomerProfile(CreateCustomerProfileDto p)
        {

            if (p.DateofBirth == null || p.CustomerId == null)
                return BadRequest("There is missing data");

            CustomerProfile newCus = new CustomerProfile()
            {
                Name = p.Name,
                Address = p.Address,
                DateofBirth = p.DateofBirth,
                PhoneNumber = p.PhoneNumber,
                CustomerId = p.CustomerId,
            };

            _context.CustomerProfiles.Add(newCus);
            _context.SaveChanges();
            return Ok();
        }


    }
}
