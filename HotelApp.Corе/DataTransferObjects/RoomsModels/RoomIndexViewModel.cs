using HotelApp.Data.Models;

namespace HotelApp_ASP.NET.ViewModels.RoomsModels
{
    public class RoomIndexViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; } 
        public string RoomTypeName { get; set; } = null!;
        public int Floor { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
    }
}
