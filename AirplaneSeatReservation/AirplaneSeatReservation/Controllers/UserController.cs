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
		public IActionResult Login()
		{
			return View();
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
	}
}