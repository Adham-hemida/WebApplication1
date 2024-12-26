using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {

        private ApplicationDbContext context;
        public ProductController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult GetAllProducts()
        {
            var products = context.Products.ToList();
            return View(products);
        }
        public IActionResult New()
        {
            //// department / كدا البيانات بتاع ال  /newبتاع ال viewهتروح وانا رايح عند  
            ViewData["depts"] = context.Products.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult saveNew(Product newEmp)
        {
            if (newEmp.Name!=null)
            {
                //var oldemp = context.Products.FirstOrDefault(x => x.ProductID == newEmp.ProductID);

                //oldemp.Name = newEmp.Name;
                //oldemp.Description = newEmp.Description;
                //oldemp.StockQuantity = newEmp.StockQuantity;
                //oldemp.Price = newEmp.Price;
                context.Products.Add(newEmp);
                context.SaveChanges();
                return RedirectToAction("GetAllProducts");
            }
            return View("New", newEmp);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
