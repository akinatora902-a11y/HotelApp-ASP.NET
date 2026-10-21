using HotelApp.Data.Models;
using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp_ASP.NET.ViewModels.RoomsModels
{
    public class RoomFormModel
    {
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

        [Required(ErrorMessage = "Room type is required.")]
        [Range(RoomIdMinValue, int.MaxValue, ErrorMessage = "Please select a valid room type.")]
        public int RoomTypeId { get; set; }

        public IEnumerable<RoomTypeEntity> RoomTypes { get; set; } = new List<RoomTypeEntity>();
    }
}
