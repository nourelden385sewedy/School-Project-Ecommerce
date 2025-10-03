using Microsoft.EntityFrameworkCore;

namespace School_ECommerce.DTOs
{
    public class UpdateOrderDto
    {
        public Guid OrderId { get; set; }

        [Precision(8, 3)]
        public decimal TotalPrice { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}
