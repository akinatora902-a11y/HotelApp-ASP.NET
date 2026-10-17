using HotelApp.Corе.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingFormModel
    {
        public int RoomId { get; set; }

        public string GuestName { get; set; } = null!;

        public string GuestEmail { get; set; } = null!;

        public string GuestPhone { get; set; } = null!;

        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Today;

        [DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; } = DateTime.Today;
        public bool IsAvailabal { get; set; }
        public IEnumerable<AvailableRoomsDropdown> Rooms { get; set; } = new List<AvailableRoomsDropdown>();
    }
}
