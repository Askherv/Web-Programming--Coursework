using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneSearReservation.Models
{
	[Table("UserLogin")]
	public class UserLogin
	{
		[Key]
		public int UserID { get; set; }

		[Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz!")]
		[Display(Name = "Kullanıcı adı")]
		[MinLength(5, ErrorMessage = "Kullanıcı adınız en az 5 karakterden oluşmalı!"), MaxLength(15, ErrorMessage = "Kullanıcı adınız en fazla 15 karakterden oluşmalı!")]
		public string? Username { get; set; }

		[Required(ErrorMessage = "Şifre boş bırakılamaz!")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterden oluşmalı!"), MaxLength(15, ErrorMessage = "Şifreniz en fazla 15 karakterden oluşmalı!")]
		public string? Password { get; set; }
	}
}