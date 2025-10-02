using School_ECommerce.Data.Models;

namespace School_ECommerce.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;

        public List<OrderDto>? Orders { get; set; }
    }
}
