using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
        [Display(Name="Quantity")]
        public int StockQuantity { get; set; }

        // Navigation property
        public  ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
