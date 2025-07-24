using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTest.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ProductName { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public ICollection<OrderItem> OrderItem { get; set; }
    }
}
