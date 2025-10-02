using Microsoft.EntityFrameworkCore;

namespace School_ECommerce.DTOs
{
    public class OrderWithProductsDto
    {
        public int Id { get; set; }

        [Precision(8, 3)]
        public decimal TotalPrice { get; set; }
        public DateTime DeliveryTime { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}
