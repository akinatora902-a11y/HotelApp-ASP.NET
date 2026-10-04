namespace HotelApp_ASP.NET.Data.Models
{
    public class RoomEntity
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public int Floor { get; set; }

        public decimal PricePerNight { get; set; }

        public int RoomTypeId { get; set; }

        public bool IsAvailable { get; set; }
    }
}
