using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSeatReservation.Models
{
	[Table("Aircraft")]
	public class Aircraft
	{
		[Key]
		public int AircraftID { get; set; }
		public string? AircraftModel { get; set; }
		public int AircraftSeats { get; set; }

	}
}