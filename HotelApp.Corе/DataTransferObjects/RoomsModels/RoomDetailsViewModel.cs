using HotelApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp_ASP.NET.ViewModels.RoomsModels
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Room number is required.")]
        [Range(RoomNumberMinValue, RoomNumberMaxValue, ErrorMessage = "Room number must be between {1} and {2}.")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Floor is required.")]
        [Range(FloorMinValue, FloorMaxValue, ErrorMessage = "Please enter a valid floor number between {1} and {2}.")]
        public int Floor { get; set; }

        [Required(ErrorMessage = "Price per night is required.")]
        [Range(PricePerNightMinValue, PricePerNightMaxValue, ErrorMessage = "Price per night must be greater than 0.")]
        public decimal PricePerNight { get; set; }

        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Room type name is required.")]
        [StringLength(RoomTypeNameMaxLength, MinimumLength = RoomTypeNameMinLength, ErrorMessage = "Room type name must be between {2} and {1} characters.")]
        public string RoomTypeName { get; set; } = string.Empty;

        [StringLength(RoomTypeDescriptionMaxLength, ErrorMessage = "Description cannot exceed {1} characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required.")]
        [Range(CapacityMinValue, CapacityMaxValue, ErrorMessage = "Capacity must be between {1} and {2} guests.")]
        public int Capacity { get; set; }
    }
}
