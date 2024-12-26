using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class GetDataWithEmployeesAndExtrainfoMV
    {// هجمع كل ال انا هبعته لل view هنا
        public List<Customer> departs { get; set; }
        public List<Order> Orders { get; set; }
        public List<Product> products { get; set; }
        public List<Payment> payments { get; set; }
        public List<Shipping> shippings { get; set; }
       
    }

}
