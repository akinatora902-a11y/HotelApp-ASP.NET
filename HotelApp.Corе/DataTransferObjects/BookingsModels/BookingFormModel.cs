namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingFormModel
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public string GuestName { get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string GuestPhone { get; set; } = null!;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public IEnumerable<DropdownRoomType> RoomType { get; set; } = new List<DropdownRoomType>();
    }
}
