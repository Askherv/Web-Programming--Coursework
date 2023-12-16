using AirplaneSeatReservation.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirplaneSeatReservation.Controllers
{
	public class UserController : Controller
	{
		private readonly FlightCS flightCS;

		public UserController(FlightCS flightCS)
		{
			this.flightCS = flightCS;
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(UserAccount addUser)
		{
			var user = new UserAccount()
			{
				UserAccountID = Guid.NewGuid(),
				FirstName = addUser.FirstName,
				LastName = addUser.LastName,
				Email = addUser.Email,
				Password = addUser.Password,
				CPassword = addUser.CPassword,

			};

			await flightCS.UserAccounts.AddAsync(user);
			await flightCS.SaveChangesAsync();
			return RedirectToAction("Register");
		}

        public IActionResult Login()
        {
            return View();
        }

		[HttpPost]
        public IActionResult Login(UserAccount addUser)
        {
			var check = flightCS.UserAccounts.Where(x=>x.Email==addUser.Email && x.Password == addUser.Password).FirstOrDefault();
			if (check != null)
			{
				HttpContext.Session.SetString("username", check.FirstName + " " + check.LastName);
				var name = HttpContext.Session.GetString("username");
				ViewBag.username = name;
				return View("Welcome");
			}
			ViewBag.error = "Kayıtlı kullanıcı bulunamadı!";
            return View();
        }

        public IActionResult Homepage()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            var name = HttpContext.Session.GetString("username");
            ViewBag.username = name;
            return View();
        }
    }
}