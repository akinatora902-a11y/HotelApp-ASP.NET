namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingDetailsViewModel
    {
        public int Id { get; set; }
        public string GuestName {  get; set; }
        public string GuestEmail { get; set; }
        public string GuestPhone { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public int RoomNumber { get; set; }
        public string RoomTypeName { get; set; }
    }
}
