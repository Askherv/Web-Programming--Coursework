using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSearReservation.Models
{
	[Table("Flight")]
	public class Flight
	{
		[Key]
		public int FlightID { get; set; }

		[ForeignKey("Route")]
		public int RouteID { get; set; }
		public Route? Route { get; set; }

		[ForeignKey("Aircraft")]
		public int AircraftID { get; set; }
		public Aircraft? Aircraft { get; set; }

		[Required]
		public DateTime DepartureTime { get; set; }
	}
}