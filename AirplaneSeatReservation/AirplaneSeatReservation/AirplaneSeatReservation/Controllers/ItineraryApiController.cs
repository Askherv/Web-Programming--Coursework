using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirplaneSeatReservation.Models; // Assuming your model is in this namespace

namespace AirplaneSeatReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItineraryApiController : ControllerBase
	{
		private readonly FlightCS flightCS; // Replace YourDbContext with your actual DbContext type

		public ItineraryApiController(FlightCS context)
		{
			flightCS = context;
		}

		// GET: api/<AircraftApiController>
		[HttpGet]
		public IActionResult Get()
		{
			var itineraries= flightCS.Itineraries.ToList();
			return Ok(itineraries);
		}

		// GET api/<AircraftApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var itinerary = flightCS.Itineraries.Find(id);

			if (itinerary == null)
			{
				return NotFound();
			}

			return Ok(itinerary);
		}

		// POST api/<AircraftApiController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Itinerary itinerary)
		{
			if (ModelState.IsValid)
			{
				await flightCS.Itineraries.AddAsync(itinerary);
				await flightCS.SaveChangesAsync();

				return CreatedAtAction(nameof(Get), new { id = itinerary.ItineraryID }, itinerary);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

		// PUT api/<AircraftApiController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Itinerary updatedItinerary)
		{
			if (id != updatedItinerary.ItineraryID)
			{
				return BadRequest();
			}

			flightCS.Entry(updatedItinerary).State = EntityState.Modified;

			try
			{
				await flightCS.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ItineraryExists(id))
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
			var itinerary = await flightCS.Itineraries.FindAsync(id);

			if (itinerary == null)
			{
				return NotFound();
			}

			flightCS.Itineraries.Remove(itinerary);
			await flightCS.SaveChangesAsync();

			return NoContent();
		}

		private bool ItineraryExists(int id)
		{
			return flightCS.Itineraries.Any(e => e.ItineraryID == id);
		}
	}
}
