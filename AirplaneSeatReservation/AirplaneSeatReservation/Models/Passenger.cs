using System.ComponentModel.DataAnnotations;

namespace AirplaneSeatReservation.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerID { get; set; }

        [Required(ErrorMessage = "İsim boş bırakılamaz!")]
        [Display(Name = "İsim")]
        public string? PassengerName { get; set; }

        [Required(ErrorMessage = "Soyisim boş bırakılamaz!")]
        [Display(Name = "Soyisim")]
        public string? PassengerSurname { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PassengerBirthDate { get; set; }

        [EnumDataType(typeof(Gender))]
        public string? PassengerGender { get; set; }

        [Required(ErrorMessage = "Email adresi boş bırakılamaz!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? PassengerEmail { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz!"), RegularExpression(@"^([0-9]{10})&", ErrorMessage = "Geçersiz telefon numarası")]
        [Display(Name = "Telefon Numarası")]
        [StringLength(10)]
        public string? PassengerPhone { get; set; }
    }
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}