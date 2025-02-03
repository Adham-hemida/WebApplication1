using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;
public class Home11Controller : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}
