using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using School_ECommerce.Data.Models;

namespace School_ECommerce.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required, MinLength(2), MaxLength(100)]
        public string Name { get; set; } = null!;

        [Precision(8, 3)]
        public decimal Price { get; set; }

        public int? Amount { get; set; } = 1;
        public string? Category { get; set; }
    }
}
