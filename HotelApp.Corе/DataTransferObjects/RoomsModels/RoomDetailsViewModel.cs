using HotelApp.Data.Models;

namespace HotelApp_ASP.NET.ViewModels.RoomsModels
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor { get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string RoomTypeName { get; set; }
        public string Description { get; set; }
        public int Capacity {  get; set; }
    }
}
