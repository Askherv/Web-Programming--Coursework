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

	[Table("Aircraft")]
	public class Aircraft
	{
		[Key]
		public int AircraftID { get; set; }
		public string? AircraftModel { get; set;}
		public int AircraftSeats { get; set; }

	}

	[Table("Route")]
	public class Route
	{
		[Key]
		public int RouteID { get; set; }
		public string? DepartureCity { get; set; }
		public string? ArrivalCity { get; set; }

	}

	[Table("Flight")]
	public class Flight
	{
		[Key]
		public int FlightID { get; set; }
		public int RouteID { get; set; }
		public int AircraftID { get; set; }

		[Required]
		public DateTime DepartureTime { get; set; }
	}

	[Table("Reservation")]
	public class Reservation
	{
		[Key]
		public int ReservationID { get; set; }
		public int FlightID { get; set; }

		[Required]
		public string? SeatNumber { get; set; }

		[Required]
		public string? PassengerName { get; set; }
	}
}