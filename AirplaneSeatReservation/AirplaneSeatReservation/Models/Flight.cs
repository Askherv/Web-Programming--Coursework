using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSeatReservation.Models
{
	[Table("Flight")]
	public class Flight
	{
		[Key]
		public Guid FlightID { get; set; }

		[ForeignKey("Route")]
		public Guid RouteID { get; set; }
		public Route? Route { get; set; }

		[ForeignKey("Aircraft")]
		public Guid AircraftID { get; set; }
		public Aircraft? Aircraft { get; set; }

		[Required]
		public DateTime DepartureTime { get; set; }
	}
}