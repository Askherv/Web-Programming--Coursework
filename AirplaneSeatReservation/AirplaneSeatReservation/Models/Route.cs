using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSeatReservation.Models
{
	[Table("Route")]
	public class Route
	{
		[Key]
		public Guid RouteID { get; set; }
		public string? DepartureCity { get; set; }
		public string? ArrivalCity { get; set; }

	}
}