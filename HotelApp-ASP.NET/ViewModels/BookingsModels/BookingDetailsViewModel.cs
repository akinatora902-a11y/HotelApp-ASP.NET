namespace HotelApp_ASP.NET.ViewModels.BookingsModels
{
    public class BookingDetailsViewModel
    {
        public int Id { get; set; }
        public string GuestName {  get; set; } = null!;
        public string GuestEmail { get; set; } = null!;
        public string GuestPhone { get; set; } = null!;
        public string CheckInDate { get; set; } = null!;
        public string CheckOutDate { get; set; } = null!;
        public decimal TotalPrice { get; set; } 
        public int RoomNumber { get; set; } 
        public string RoomTypeName { get; set; } = null!;
    }
}
