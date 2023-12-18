using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AirplaneSeatReservation.Models;

namespace AirplaneSeatReservation.Models
{
	[Table("Reservation")]
	public class Reservation
	{
		[Key]
		public int ReservationID { get; set; }

		[ForeignKey("Flight")]
		public int FlightID { get; set; }
		public Flight? Flight { get; set; }

		[Required]
		public string? SeatNumber { get; set; }

        [ForeignKey("Passenger")]
		public int PassengerID { get; set; }
		public Passenger? Passenger { get; set; }
    }
}