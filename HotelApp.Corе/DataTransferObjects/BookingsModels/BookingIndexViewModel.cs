using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingIndexViewModel
    {
        public int Id { get; set; }

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
        public string CheckInDate { get; set; } = null!;

        [Required(ErrorMessage = "Check-out date is required.")]
        public string CheckOutDate { get; set; } = null!;

        [Range(TotalPriceMinValue, TotalPriceMaxValue, ErrorMessage = "Total price must be greater than 0.")]
        public decimal TotalPrice { get; set; }

        [Required(ErrorMessage = "Room number is required.")]
        [Range(RoomNumberMinValue, RoomNumberMaxValue, ErrorMessage = "Room number must be between {1} and {2}.")]
        public int RoomNumber { get; set; }

    }
}
