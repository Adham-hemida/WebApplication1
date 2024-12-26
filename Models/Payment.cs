using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Payment
    {

        [Key]
        public int PaymentID { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal Amount { get; set; }

        // Navigation property
        [ForeignKey(nameof(Order))]
        public int OrderID { get; set; }
        public Order Order { get; set; }
    }
}
