using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSeatReservation.Models
{
	[Table("Flight")]
	public class Flight
	{
		[Key]
		public int FlightID { get; set; }

		[ForeignKey("Itinerary")]
		public int ItineraryID { get; set; }
		public Itinerary? Itinerary { get; set; }

        [ForeignKey("Aircraft")]
		public int AircraftID { get; set; }
		public Aircraft? Aircraft { get; set; }
	}
}