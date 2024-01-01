using AirplaneSeatReservation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using AirplaneSeatReservation.Services;

namespace AirplaneSeatReservation.Controllers
{
	public class MainController : Controller
	{
        private  LanguageService _localization;
        private readonly FlightCS flightCS;

        public MainController(FlightCS flightCS, LanguageService localization)
        {
            _localization = localization;
            this.flightCS = flightCS;
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public IActionResult Homepage()
		{
            ViewBag.Welcome = _localization.Getkey("Welcome").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
			return View();
		}

		[HttpGet]
		public IActionResult Welcome()
		{
            ViewBag.Welcome = _localization.Getkey("Welcome").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            var name = HttpContext.Session.GetString("username");
			ViewBag.username = name;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Welcome(Reservation addReservation, string PassengerPassportNo, string DepartureCity, string ArrivalCity, int SeatNo)
		{
            ViewBag.Welcome = _localization.Getkey("Welcome").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            var name = HttpContext.Session.GetString("username");
            ViewBag.username = name;

            var passportExists = flightCS.Reservations.Any(x => x.PassengerPassportNo == PassengerPassportNo);
            var depExists = flightCS.Reservations.Any(x => x.DepartureCity == DepartureCity);
            var arrExists = flightCS.Reservations.Any(x => x.ArrivalCity == ArrivalCity);
            var seatExists = flightCS.Reservations.Any(x => x.SeatNo == SeatNo);
            if (passportExists && depExists && arrExists)
            {
                ViewBag.error = "Bu pasaport numarası için bu güzergahta zaten bir rezervasyon oluşturulmuştur!";
                return View();
            }

            if (depExists && arrExists && seatExists)
            {
                ViewBag.error = "Koltuk Dolu!";
                return View();
            }

            var reservation = new Reservation()
            {
                ReservationID = addReservation.ReservationID,
                PassengerName = addReservation.PassengerName,
				PassengerSurname = addReservation.PassengerSurname,
				PassengerGender = addReservation.PassengerGender,
				PassengerPassportNo = addReservation.PassengerPassportNo,
				PassengerBirthDate = addReservation.PassengerBirthDate,
                PassengerEmail = addReservation.PassengerEmail,
                DepartureCity = addReservation.DepartureCity,
                ArrivalCity = addReservation.ArrivalCity,
                DepartureDate = addReservation.DepartureDate,
                SeatNo = addReservation.SeatNo,
            };

            await flightCS.Reservations.AddAsync(reservation);
            await flightCS.SaveChangesAsync();
            ViewBag.correct = "Rezervasyon başarıyla oluşturuldu!";
            return View("Welcome");
        }
	}
}
