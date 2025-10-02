using Microsoft.EntityFrameworkCore;

namespace School_ECommerce.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; }

        [Precision(8, 3)]
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryTime { get; set; } = DateTime.Now.AddDays(3);

        public CustomerOrderDto? Customerdto { get; set; }
    }
}
