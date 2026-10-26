using System.ComponentModel.DataAnnotations;
using static HotelApp.Common.ValidationConstants.EntityValidation;

namespace HotelApp_ASP.NET.ViewModels.RoomsModels
{
    public class RoomFormModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Room number is required.")]
        [Range(RoomNumberMinValue, RoomNumberMaxValue, ErrorMessage = "Room number must be between {1} and {2}.")]
        public int RoomNumber { get; set; }

        [Required(ErrorMessage = "Floor is required.")]
        [Range(FloorMinValue, FloorMaxValue, ErrorMessage = "Please enter a valid floor number between {1} and {2}.")]
        public int Floor { get; set; }

        public bool IsAvailable { get; set; }

        [Required(ErrorMessage = "Room type is required.")]
        [Range(RoomIdMinValue, int.MaxValue, ErrorMessage = "Please select a valid room type.")]
        public int RoomTypeId { get; set; }
        public IEnumerable<DropdownRoomType> RoomTypes { get; set; } = new List<DropdownRoomType>();
    }
}
