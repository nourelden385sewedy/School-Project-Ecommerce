using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace School_ECommerce.DTOs
{
    public class CreateProductDto
    {

        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; } = null!;

        [Precision(8, 3)]
        public decimal Price { get; set; }

        public int? Amount { get; set; } = 1;
        public int CategoryId { get; set; }
    }
}
