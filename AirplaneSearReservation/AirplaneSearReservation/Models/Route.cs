using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirplaneSearReservation.Models
{
	[Table("Route")]
	public class Route
	{
		[Key]
		public int RouteID { get; set; }
		public string? DepartureCity { get; set; }
		public string? ArrivalCity { get; set; }

	}
}