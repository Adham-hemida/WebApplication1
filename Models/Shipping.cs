using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Shipping
    {
        [Key] 
        public int ShippingID { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingDate { get; set; }
        public string Status { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }
        // Navigation property
        public Order Order { get; set; }
    }
}
