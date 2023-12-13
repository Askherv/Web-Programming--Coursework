using Microsoft.AspNetCore.Mvc;

namespace AirplaneSeatReservation.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

    }
}
