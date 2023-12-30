using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneSeatReservation.Models
{
        [Table("Admin")]
        public class Admin
        {
        [Key]
        public int AdminID { get; set; }

        [Required(ErrorMessage = "Email adresi boş bırakılamaz!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Şifre boş bırakılamaz!")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterden oluşmalı!"), MaxLength(15, ErrorMessage = "Şifreniz en fazla 15 karakterden oluşmalı!")]
        public string? Password { get; set; }
		public string? Role { get; internal set; }
	}
 }