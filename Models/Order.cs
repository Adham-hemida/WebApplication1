using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
		public string OrderNumber { get; set; }
       
		[Display(Name ="Date of Order")]
        public string OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string Status { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        
        // Navigation properties
        public Customer Customer { get; set; }
        public  ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
