namespace HotelApp_ASP.NET.Data.Models
{
    public class BookingEntity
    {
        public int Id { get; set; }

        public string GuestName { get; set; }

        public string GuestEmail { get; set; }

        public int GuestPhone { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public decimal TotalPrice { get; set; }

        public int RoomId { get; set; }
    }
}
