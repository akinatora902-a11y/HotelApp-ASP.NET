using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingFormModel
    {
        public int RoomId { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public IEnumerable<SelectListItem> AvailableRooms { get; set; } = new List<SelectListItem>();
    }
}
