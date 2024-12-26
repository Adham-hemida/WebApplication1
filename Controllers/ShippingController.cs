using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class ShippingController : Controller
	{

		private ApplicationDbContext context;
		public ShippingController(ApplicationDbContext _context)
		{
			context = _context;
		}
		public IActionResult GetAllShippings()
		{
			var products = context.Shippings.ToList();
			return View(products);
		}
		public IActionResult New()
		{
			//// department / كدا البيانات بتاع ال  /newبتاع ال viewهتروح وانا رايح عند  
			ViewData["depts"] = context.Payments.ToList();

			return View();
		}
		[HttpPost]
		public IActionResult saveNew(Shipping newEmp)
		{
			if (newEmp.ShippingAddress!=null)
			{
			//	var oldemp = context.Shippings.FirstOrDefault(x => x.ShippingID == newEmp.ShippingID);

			//	oldemp.ShippingAddress = newEmp.ShippingAddress;
			//	oldemp.ShippingDate = newEmp.ShippingDate;
		 	//	oldemp.Status = newEmp.Status;
			context.Shippings.Add(newEmp);	
				context.SaveChanges();
				return RedirectToAction("GetAllShippings");
			}
			return View("New", newEmp);
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
