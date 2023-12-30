using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirplaneSeatReservation.Models; // Assuming your model is in this namespace

namespace AirplaneSeatReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AircraftApiController : ControllerBase
	{
		private readonly FlightCS flightCS; // Replace YourDbContext with your actual DbContext type

		public AircraftApiController(FlightCS context)
		{
			flightCS = context;
		}

		// GET: api/<AircraftApiController>
		[HttpGet]
		public IActionResult Get()
		{
			var aircrafts = flightCS.Aircrafts.ToList();
			return Ok(aircrafts);
		}

		// GET api/<AircraftApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var aircraft = flightCS.Aircrafts.Find(id);

			if (aircraft == null)
			{
				return NotFound();
			}

			return Ok(aircraft);
		}

		// POST api/<AircraftApiController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Aircraft aircraft)
		{
			if (ModelState.IsValid)
			{
				await flightCS.Aircrafts.AddAsync(aircraft);
				await flightCS.SaveChangesAsync();

				return CreatedAtAction(nameof(Get), new { id = aircraft.AircraftID }, aircraft);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

		// PUT api/<AircraftApiController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Aircraft updatedAircraft)
		{
			if (id != updatedAircraft.AircraftID)
			{
				return BadRequest();
			}

			flightCS.Entry(updatedAircraft).State = EntityState.Modified;

			try
			{
				await flightCS.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!AircraftExists(id))
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
			var aircraft = await flightCS.Aircrafts.FindAsync(id);

			if (aircraft == null)
			{
				return NotFound();
			}

			flightCS.Aircrafts.Remove(aircraft);
			await flightCS.SaveChangesAsync();

			return NoContent();
		}

		private bool AircraftExists(int id)
		{
			return flightCS.Aircrafts.Any(e => e.AircraftID == id);
		}
	}
}
