using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AirplaneSeatReservation.Models;
using System.Collections.Generic;

namespace AirplaneSeatReservation.Models
{
	public class FlightCS : DbContext
	{
		private readonly IConfiguration _configuration;

		public FlightCS()
		{
		}

		public FlightCS(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
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
