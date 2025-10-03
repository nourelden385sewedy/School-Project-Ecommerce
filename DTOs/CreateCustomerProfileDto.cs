using School_ECommerce.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_ECommerce.DTOs
{
    public class CreateCustomerProfileDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateOnly DateofBirth { get; set; }
        public string? PhoneNumber { get; set; }

        public int CustomerId { get; set; }
    }
}
