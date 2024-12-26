using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class PaymentController : Controller
	{

		private ApplicationDbContext context;
		public PaymentController(ApplicationDbContext _context)
		{
			context = _context;
		}
		public IActionResult GetAllPayments()
		{
			var products = context.Payments.ToList();
			return View(products);
		}
		public IActionResult New()
		{
			//// department / كدا البيانات بتاع ال  /newبتاع ال viewهتروح وانا رايح عند  
			ViewData["depts"] = context.Payments.ToList();

			return View();
		}
		[HttpPost]
		public IActionResult saveNew(Payment newEmp)
		{
			if (newEmp.Amount!=null)
			{
			//	var oldemp = context.Payments.FirstOrDefault(x => x.PaymentID == newEmp.PaymentID);

			//	oldemp.PaymentMethod = newEmp.PaymentMethod;
			//	oldemp.PaymentDate = newEmp.PaymentDate;
			//	oldemp.Amount = newEmp.Amount;
			context.Payments.Add(newEmp);
   
				context.SaveChanges();
				return RedirectToAction("GetAllPayments");
			}
			return View("New", newEmp);
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
