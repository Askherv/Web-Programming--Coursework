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
		public string? PassengerName { get; set; }
		public string? PassengerSurname { get; set; }
		public string? PassengerGender { get; set; }
		public string? PassengerPassportNo { get; set; }
		public string? PassengerBirthDate { get; set; }
		public string? PassengerEmail { get; set; }
		public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public string? DepartureDate { get; set; }
		public int? SeatNo { get; set; }
    }
}