using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneSeatReservation.Models
{
    [Table("Itinerary")]
    public class Itinerary
    {
        [Key]
        public int ItineraryID { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public string? DepartureAirport { get; set; }
        public string? ArrivalAirport { get; set; }

        [DataType(DataType.Date)]
        public String? DepartureDate { get; set; }

        [DataType(DataType.Time)]
        public String? DepartureTime { get; set; }
    }
}
