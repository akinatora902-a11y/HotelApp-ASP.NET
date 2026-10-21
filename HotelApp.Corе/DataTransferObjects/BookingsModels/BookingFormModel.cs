using HotelApp.Corе.DataTransferObjects;
using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingFormModel
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Guest name is required.")]
        [StringLength(GuestNameMaxLength, MinimumLength = GuestNameMinLength, ErrorMessage = "Guest name must be between {2} and {1} characters.")]
        public string GuestName { get; set; } = null!;

        [Required(ErrorMessage = "Email address is required.")]
        [StringLength(GuestEmailMaxLength, MinimumLength = GuestEmailMinLength, ErrorMessage = "Guest email must be between {2} and {1} characters.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string GuestEmail { get; set; } = null!;

        [Required(ErrorMessage = "Phone number is required.")]
        [StringLength(GuestPhoneMaxLength, MinimumLength = GuestPhoneMinLength, ErrorMessage = "Guest phone must be between {2} and {1} characters.")]
        [Phone(ErrorMessage = "Please enter a valid phone number.")]
        public string GuestPhone { get; set; } = null!;

        [Required(ErrorMessage = "Check-in date is required.")]
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "Check-out date is required.")]
        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; } = DateTime.Today;

        public bool IsAvailabal { get; set; }

        public IEnumerable<AvailableRoomsDropdown> Rooms { get; set; } = new List<AvailableRoomsDropdown>();
    }
}
