using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneSeatReservation.Controllers
{
	public class MainController : Controller
	{
		public IActionResult Homepage()
		{
			return View();
		}

		[Authorize(Roles = "Ui")]
		public IActionResult Welcome()
		{
			var name = HttpContext.Session.GetString("username");
			ViewBag.username = name;
			return View();
		}
	}
}
