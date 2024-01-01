using AirplaneSeatReservation.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
		public async Task<IActionResult> Register(UserAccount addUser, string Email)
		{
            var EmailExists = flightCS.UserAccounts.Any(x => x.Email == Email);
            if(EmailExists) 
			{
                ViewBag.error = "Bu email adresi zaten kayıtlı!";
                return View();
            }

            if (addUser.Password != addUser.CPassword)
            {
                ViewBag.error = "Şifreler eşleşmiyor!";
                return View();
            }

            var user = new UserAccount()
			{
				UserAccountID = addUser.UserAccountID,
				FirstName = addUser.FirstName,
				LastName = addUser.LastName,
				Email = addUser.Email,
				Password = addUser.Password,
				CPassword = addUser.CPassword,

			};

			await flightCS.UserAccounts.AddAsync(user);
			await flightCS.SaveChangesAsync();
            ViewBag.correct = "Kayıt başarıyla tamamlandı! Giriş yapabilmek için lütfen Giriş Yap sayfasına geçiniz.";
			return View("Register");
		}

		[HttpGet]
		public IActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Login(UserAccount addUser)
		{
			var check = flightCS.UserAccounts.Where(x => x.Email == addUser.Email && x.Password == addUser.Password).FirstOrDefault();
			if (check != null)
			{
				if (check.Email.ToLower() == "b211210554@sakarya.edu.tr" || check.Email.ToLower() == "b211210002@sakarya.edu.tr")
				{
					check.Role = "Admin";
				}
				else
				{
					check.Role = "Ui";
				}
				var claims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, check.FirstName + " " + check.LastName),
					new Claim(ClaimTypes.Role, "Ui"),
					new Claim(ClaimTypes.Role, "Admin"),
				};

				var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				var authProperties = new AuthenticationProperties();

				await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(claimsIdentity), authProperties);

				HttpContext.Session.SetString("username", check.FirstName + " " + check.LastName);
				var name = HttpContext.Session.GetString("username");
				ViewBag.username = name;

				if (check.Role == "Ui")
				{
					return RedirectToAction("Welcome", "Main");
				}
				else if (check.Role == "Admin")
				{
					return RedirectToAction("Index", "Admin");
				}
			}
			ViewBag.error = "Kayıtlı kullanıcı bulunamadı!";
			return View();
		}
	}
}