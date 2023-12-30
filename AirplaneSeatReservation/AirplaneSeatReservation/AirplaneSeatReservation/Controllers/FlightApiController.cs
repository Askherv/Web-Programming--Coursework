using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirplaneSeatReservation.Models; // Assuming your model is in this namespace

namespace AirplaneSeatReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FlightApiController : ControllerBase
	{
		private readonly FlightCS flightCS; // Replace YourDbContext with your actual DbContext type

		public FlightApiController(FlightCS context)
		{
			flightCS = context;
		}

		// GET: api/<AircraftApiController>
		[HttpGet]
		public IActionResult Get()
		{
			var flights = flightCS.Flights.ToList();
			return Ok(flights);
		}

		// GET api/<AircraftApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var flight = flightCS.Flights.Find(id);

			if (flight == null)
			{
				return NotFound();
			}

			return Ok(flight);
		}

		// POST api/<AircraftApiController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Flight flight)
		{
			if (ModelState.IsValid)
			{
				await flightCS.Flights.AddAsync(flight);
				await flightCS.SaveChangesAsync();

				return CreatedAtAction(nameof(Get), new { id = flight.FlightID }, flight);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

		// PUT api/<AircraftApiController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Flight updatedFlight)
		{
			if (id != updatedFlight.FlightID)
			{
				return BadRequest();
			}

			flightCS.Entry(updatedFlight).State = EntityState.Modified;

			try
			{
				await flightCS.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!FlightExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		// DELETE api/<AircraftApiController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var flight = await flightCS.Flights.FindAsync(id);

			if (flight == null)
			{
				return NotFound();
			}

			flightCS.Flights.Remove(flight);
			await flightCS.SaveChangesAsync();

			return NoContent();
		}

		private bool FlightExists(int id)
		{
			return flightCS.Flights.Any(e => e.FlightID == id);
		}
	}
}
