using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School_ECommerce.Data.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; } = null!;

        [Precision(8, 3)]
        public decimal Price { get; set; }

        public int? Amount { get; set; } = 1;


        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;

        [JsonIgnore]
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    }
}
