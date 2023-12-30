using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AirplaneSeatReservation.Models; // Assuming your model is in this namespace

namespace AirplaneSeatReservation.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserApiController : ControllerBase
	{
		private readonly FlightCS flightCS; // Replace YourDbContext with your actual DbContext type

		public UserApiController(FlightCS context)
		{
			flightCS = context;
		}

		// GET: api/<AircraftApiController>
		[HttpGet]
		public IActionResult Get()
		{
			var users = flightCS.UserAccounts.ToList();
			return Ok(users);
		}

		// GET api/<AircraftApiController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var user = flightCS.UserAccounts.Find(id);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(user);
		}

		// POST api/<AircraftApiController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] UserAccount user)
		{
			if (ModelState.IsValid)
			{
				await flightCS.UserAccounts.AddAsync(user);
				await flightCS.SaveChangesAsync();

				return CreatedAtAction(nameof(Get), new { id = user.UserAccountID }, user);
			}
			else
			{
				return BadRequest(ModelState);
			}
		}

		// PUT api/<AircraftApiController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] UserAccount updatedUserAccount)
		{
			if (id != updatedUserAccount.UserAccountID)
			{
				return BadRequest();
			}

			flightCS.Entry(updatedUserAccount).State = EntityState.Modified;

			try
			{
				await flightCS.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserAccountExists(id))
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
			var user = await flightCS.UserAccounts.FindAsync(id);

			if (user == null)
			{
				return NotFound();
			}

			flightCS.UserAccounts.Remove(user);
			await flightCS.SaveChangesAsync();

			return NoContent();
		}

		private bool UserAccountExists(int id)
		{
			return flightCS.UserAccounts.Any(e => e.UserAccountID == id);
		}
	}
}
