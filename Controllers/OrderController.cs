using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {

        private ApplicationDbContext context;
        public OrderController(ApplicationDbContext _context)
        {
            context = _context;
        }
        public IActionResult GetAllOrders()
        {
            var orders = context.Orders.ToList();
            return View(orders);
        }
		public IActionResult New()
		{
			//// department / كدا البيانات بتاع ال  /newبتاع ال viewهتروح وانا رايح عند  
			ViewData["depts"] = context.Orders.ToList();

			return View();
		}
		[HttpPost]
		public IActionResult saveNew(Order newEmp)
		{
			if (newEmp.CustomerID!=null)
			{
				//var oldemp = context.Orders.FirstOrDefault(x => x.OrderID == newEmp.OrderID);

				//oldemp.OrderDate = newEmp.OrderDate;
				//oldemp.TotalAmount = newEmp.TotalAmount;
				//oldemp.Status = newEmp.Status;
				//oldemp.CustomerID = newEmp.CustomerID;
				//oldemp.OrderDetails = newEmp.OrderDetails;

				context.Orders.Add(newEmp);
				context.SaveChanges();
				return RedirectToAction("GetAllOrders");
			}
			return View("New", newEmp);
		}
		public IActionResult Index()
        {
            return View();
        }
    }
}
