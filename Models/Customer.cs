using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Customer
    {
            [Key]
            public int CustomerID { get; set; }

            [Required]
            public string Name { get; set; }

            [Required]
            public string Email { get; set; }

            public string Address { get; set; }
            public string PhoneNumber { get; set; }

            // Navigation property
            public  ICollection<Order> Orders { get; set; }
        
    }
}
