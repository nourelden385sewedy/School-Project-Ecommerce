using System.ComponentModel.DataAnnotations;

namespace School_ECommerce.Data.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [EmailAddress]// @gmail
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;


        public List<Order> Orders { get; set; } = new List<Order>();
        public CustomerProfile CustomerProfile { get; set; } = null!;
    }
}
