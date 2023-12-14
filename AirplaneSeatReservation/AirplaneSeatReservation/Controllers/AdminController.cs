using Microsoft.AspNetCore.Mvc;

namespace AirplaneSeatReservation.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

        public IActionResult Aircraft()
        {
            return View();
        }

        public IActionResult Flight()
        {
            return View();
        }

        public IActionResult Route()
        {
            return View();
        }

        public IActionResult Reservation()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

    }
}
