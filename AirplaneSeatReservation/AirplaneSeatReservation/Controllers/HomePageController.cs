using Microsoft.AspNetCore.Mvc;

namespace AirplaneSeatReservation.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Welcome()
        {
            return View();
        }
    }
}
