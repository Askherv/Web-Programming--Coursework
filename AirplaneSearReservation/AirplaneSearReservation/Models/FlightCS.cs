using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AirplaneSearReservation.Models
{
	public class FlightCS : DbContext
	{
		private readonly IConfiguration _configuration;

		public FlightCS(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public DbSet<UserLogin> UserLogins { get; set; }
		public DbSet<UserAccount> UserAccounts { get; set; }
		public DbSet<Aircraft> Aircrafts { get; set; }
		public DbSet<Route> Routes { get; set; }
		public DbSet<Flight> Flights { get; set; }
		public DbSet<Reservation> Reservations { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
			}
		}
	}
}
