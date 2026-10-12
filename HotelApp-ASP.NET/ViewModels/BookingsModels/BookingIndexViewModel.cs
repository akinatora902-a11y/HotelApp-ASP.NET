namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingIndexViewModel
    {
        public int Id { get; set; }
        public string GuestName { get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int RoomNumber { get; set; }

    }
}
