using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSearReservation.Models
{
	[Table("Reservation")]
	public class Reservation
	{
		[Key]
		public int ReservationID { get; set; }
		public int FlightID { get; set; }

		[Required]
		public string? SeatNumber { get; set; }

		[Required]
		public string? PassengerName { get; set; }
	}
}