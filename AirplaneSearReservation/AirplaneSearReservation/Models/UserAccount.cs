using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirplaneSearReservation.Models
{
		[Table("UserAccount")]
		public class UserAccount
		{
			[Key]
			public int UserAccountID { get; set; }

			[Required(ErrorMessage = "İsim boş bırakılamaz!")]
			[Display(Name = "İsim")]
			public string? FirstName { get; set; }

			[Required(ErrorMessage = "Soyad boş bırakılamaz!")]
			[Display(Name = "Soyad")]
			public string? LastName { get; set; }

			[Required(ErrorMessage = "Email adresi boş bırakılamaz!")]
			[Display(Name = "Email")]
			[DataType(DataType.EmailAddress)]
			public string? Email { get; set; }

			[Required(ErrorMessage = "Şifre boş bırakılamaz!")]
			[DataType(DataType.Password)]
			[MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterden oluşmalı!"), MaxLength(15, ErrorMessage = "Şifreniz en fazla 15 karakterden oluşmalı!")]
			public string? Password { get; set; }

			[Required(ErrorMessage = "Şifre boş bırakılamaz!")]
			[Display(Name = "Şifreyi onaylayınız")]
			[Compare("Password", ErrorMessage = "Şifreler eşleşmedi")]
			[DataType(DataType.Password)]
			[MinLength(6, ErrorMessage = "Şifreniz en az 6 karakterden oluşmalı!"), MaxLength(15, ErrorMessage = "Şifreniz en fazla 15 karakterden oluşmalı!")]
			public string? CPassword { get; set; }

			[Required(ErrorMessage = "Telefon numarası boş bırakılamaz!"), RegularExpression(@"^([0-9]{10})&", ErrorMessage = "Geçersiz telefon numarası")]
			[Display(Name = "Telefon Numarası")]
			[StringLength(10)]
			public string? TelNo { get; set; }
		}
}