using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace School_ECommerce.Data.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {
        public int Id { get; set; }

        [Precision(8, 3)]
        public decimal PriceAtOrder { get; set; }
        public int? Amount { get; set; } = 1;


        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
