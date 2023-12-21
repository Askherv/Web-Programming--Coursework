using AirplaneSeatReservation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirplaneSeatReservation.Controllers
{
	[Authorize(Roles ="Admin")]
	public class AdminController : Controller
	{
        private readonly FlightCS flightCS;

        public AdminController(FlightCS flightCS)
        {
            this.flightCS = flightCS;
        }
        public IActionResult Index()
		{
			return View();
		}

        [HttpGet]
        public IActionResult Aircraft()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Aircraft(Aircraft addAircraft, string AircraftModel)
        {
            var aircraftExists = flightCS.Aircrafts.Any(x => x.AircraftModel == AircraftModel);
            if (aircraftExists)
            {
                ViewBag.error = "Böyle bir uçak zaten kayıtlı!";
                return View();
            }
            var aircraft = new Aircraft()
            {
                AircraftID = addAircraft.AircraftID,
                AircraftModel = addAircraft.AircraftModel,
                AircraftSeats = addAircraft.AircraftSeats,
            };

            await flightCS.Aircrafts.AddAsync(aircraft);
            await flightCS.SaveChangesAsync();
            ViewBag.correct = "Uçak başarıyla eklendi!";
            return View("Aircraft");
        }

        [HttpGet]
        public async Task<IActionResult> AircraftList()
        {
			var aircrafts = await flightCS.Aircrafts.ToListAsync();
			return View(aircrafts);
		}

		[HttpGet]
        public IActionResult Flight()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Flight(Flight  addFlight, int aircraftID, int itineraryID)
        {
            var aircraftDontExists = flightCS.Aircrafts.Any(x => x.AircraftID == aircraftID);
            var itineraryDontExists = flightCS.Itineraries.Any(x => x.ItineraryID == itineraryID);
            if(!aircraftDontExists || !itineraryDontExists)
            {
                ViewBag.error = "Kayıtlı uçak no veya güzergah no bulunamadı!";
                return View();
            }

            var aircraftExists = flightCS.Flights.Any(x => x.AircraftID == aircraftID);
            var itineraryExists = flightCS.Flights.Any(x => x.ItineraryID == itineraryID);
            if (aircraftExists && itineraryExists)
            {
                ViewBag.error = "Böyle bir uçuş zaten kayıtlı!";
                return View();
            }

            var flight = new Flight()
            {
                FlightID = addFlight.FlightID,
                AircraftID = aircraftID,
                ItineraryID = itineraryID,
            };

            await flightCS.Flights.AddAsync(flight);
            await flightCS.SaveChangesAsync();
            ViewBag.correct = "Uçuş başarıyla eklendi!";
            return View("Flight");
        }

        [HttpGet]
        public async Task<IActionResult> FlightList()
        {
			var flights = await flightCS.Flights.ToListAsync();
			return View(flights);
		}

        [HttpGet]
        public IActionResult Route()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Route(Itinerary addItinerary, string DepartureCity, string ArrivalCity, string DepartureAirport, string ArrivalAirport, string DepartureDate, string DepartureTime)
        {
            var DepartureCityExists = flightCS.Itineraries.Any(x => x.DepartureCity == DepartureCity);
            var ArrivalCityExists = flightCS.Itineraries.Any(x => x.ArrivalCity == ArrivalCity);
            var DepartureAirportExists = flightCS.Itineraries.Any(x => x.DepartureAirport == DepartureAirport);
            var ArrivalAirportExists = flightCS.Itineraries.Any(x => x.ArrivalAirport == ArrivalAirport);
            var DepartureDateExists = flightCS.Itineraries.Any(x => x.DepartureDate == DepartureDate);
            var DepartureTimeExists = flightCS.Itineraries.Any(x => x.DepartureTime == DepartureTime);
            if (DepartureCityExists && ArrivalCityExists && DepartureAirportExists && ArrivalAirportExists && DepartureDateExists && DepartureTimeExists)
            {
                ViewBag.error = "Böyle bir güzergah zaten tanımlı!";
                return View();
            }
            var itinerary = new Itinerary()
            {
                ItineraryID = addItinerary.ItineraryID,
                DepartureCity = addItinerary.DepartureCity,
                ArrivalCity = addItinerary.ArrivalCity,
                DepartureAirport = addItinerary.DepartureAirport,
                ArrivalAirport = addItinerary.ArrivalAirport,
                DepartureDate = addItinerary.DepartureDate,
                DepartureTime = addItinerary.DepartureTime,
            };

            await flightCS.Itineraries.AddAsync(itinerary);
            await flightCS.SaveChangesAsync();
            ViewBag.correct = "Güzergah başarıyla eklendi!";
            return View("Route");
        }

        [HttpGet]
        public async Task<IActionResult> RouteList()
        {
			var itineraries = await flightCS.Itineraries.ToListAsync();
			return View(itineraries);
		}

        public IActionResult Reservation()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await flightCS.UserAccounts.ToListAsync();
            return View(users);
        }

    }
}