using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace School_ECommerce.DTOs
{
    public class CreateOrderDto
    {
        public Guid OrderId { get; set; } = Guid.NewGuid();

        [Precision(8, 3)]
        [JsonIgnore]
        public decimal TotalPrice { get; set; }
        public int CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
}
