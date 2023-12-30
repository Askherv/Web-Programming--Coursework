using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneSeatReservation.Models
{
	[Table("UserAccount")]
	public class UserAccount
	{
		[Key]
		public int UserAccountID { get; set; }

		[Required(ErrorMessage = "İsim boş bırakılamaz!")]
		[Display(Name = "İsim")]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "Soyisim boş bırakılamaz!")]
		[Display(Name = "Soyisim")]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "Email adresi boş bırakılamaz!")]
		[Display(Name = "Email")]
		[DataType(DataType.EmailAddress)]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Şifre boş bırakılamaz!")]
		[Display(Name = "Şifre")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterden oluşmalı!"), MaxLength(15, ErrorMessage = "Şifreniz en fazla 15 karakterden oluşmalı!")]
		public string? Password { get; set; }

		[Required(ErrorMessage = "Şifre boş bırakılamaz!")]
		[Display(Name = "Şifreyi onaylayınız")]
		[Compare("Password", ErrorMessage = "Şifreler eşleşmedi")]
		[DataType(DataType.Password)]
		[MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterden oluşmalı!"), MaxLength(15, ErrorMessage = "Şifreniz en fazla 15 karakterden oluşmalı!")]
		public string? CPassword { get; set; }
		public string? Role { get; internal set; }
	}
}