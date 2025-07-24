using System.ComponentModel.DataAnnotations;

namespace BaiTest.DTOs
{
    public class UpdateProductDTO
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
