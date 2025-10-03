using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School_ECommerce.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public Guid OrderId { get; set; } = Guid.NewGuid();

        [Precision(8, 3)]
        public decimal TotalPrice { get; set; }
        public DateOnly DeliveryTime { get; set; } = DateOnly.FromDateTime(DateTime.Now.AddDays(2));



        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [JsonIgnore]

        public Customer Customer { get; set; } = null!;
    }
}
