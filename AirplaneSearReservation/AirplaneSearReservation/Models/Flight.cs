using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSearReservation.Models
{
	[Table("Flight")]
	public class Flight
	{
		[Key]
		public int FlightID { get; set; }
		public int RouteID { get; set; }
		public int AircraftID { get; set; }

		[Required]
		public DateTime DepartureTime { get; set; }
	}
}