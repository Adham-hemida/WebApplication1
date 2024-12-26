using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;
        public CustomerController(ApplicationDbContext _context)
        {
            context = _context;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllCustomers()
        {
            var customers= context.Customers.Include(e => e.Orders).ToList();
			return View(customers);
        }

        public IActionResult Edit(int id)
        {
            var emp = context.Customers.FirstOrDefault(x => x.CustomerID == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult SaveEdit(int id, Customer emp)
        {
            if (ModelState.IsValid)
            {
                var oldemp = context.Customers.FirstOrDefault(x => x.Name == emp.Name);
                if (oldemp != null)
                {
                    //if (oldemp != null)
                    //{
                    //    oldemp.CustomerID = emp.CustomerID;
                    //    oldemp.Name = emp.Name;
                    //    oldemp.Address = emp.Address;
                    //    oldemp.Email = emp.Email;
                    //    oldemp.Address = emp.Address;
                    //    oldemp.PhoneNumber = emp.PhoneNumber;
                    context.Add(oldemp);
                    context.SaveChanges();
                    return RedirectToAction("GetAllCustomers");
                }
                //}

            }
            return View("Edit", emp);
        }
        [HttpGet]
        public IActionResult New()
        {
            //// department / كدا البيانات بتاع ال  /newبتاع ال viewهتروح وانا رايح عند  
            ViewData["depts"] = context.Orders.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult saveNew(Customer newEmp)
        {if (ModelState.IsValid)
            {
               // var oldemp = context.Customers.FirstOrDefault(x => x.Name == newEmp.Name);
                if (newEmp.Name != null)
                {
                    //oldemp.Name = newEmp.Name;
                    //oldemp.CustomerID = newEmp.CustomerID;
                    //oldemp.Address = newEmp.Address;
                    //oldemp.Email = newEmp.Email;
                    //oldemp.Orders = newEmp.Orders;
                    //context.Update(oldemp);
                    context.Customers.Add(newEmp);
                    context.SaveChanges();
                    return RedirectToAction("GetAllCustomers");
                }
            }
            return View("New", newEmp);
        }

		public ActionResult Delete(int id)
		{
			var emp =context.Customers.FirstOrDefault(x => x.CustomerID == id);
			context.Remove(emp);
			context.SaveChanges();
			return RedirectToAction("GetAllCustomers");
		}

		public void Update(Customer newEmp, int id)
		{
			Customer? employeeFormDb = context.Customers.FirstOrDefault(e => e.CustomerID == id);
			employeeFormDb.Name = newEmp.Name;
			employeeFormDb.Email = newEmp.Email;
			employeeFormDb.Address = newEmp.Address;
            employeeFormDb.Orders = newEmp.Orders.ToList();
		
			context.SaveChanges();

		}
	}
}
