using Microsoft.AspNetCore.Mvc;

namespace AirplaneSearReservation.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
