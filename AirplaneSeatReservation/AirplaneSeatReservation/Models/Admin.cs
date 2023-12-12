using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneSeatReservation.Models
{
        [Table("Admin")]
        public class Admin
        {
            [Key]
            public Guid AdminID { get; set; }
            public string? AdminName { get; set; }
            public string? AdminPassword { get; set; }
        }
    }