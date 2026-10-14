using HotelApp.Data.Models;

namespace HotelApp_ASP.NET.ViewModels.RoomsModels
{
    public class RoomFormModel
    {
        public int RoomNumber { get; set; }
        public int Floor {  get; set; }
        public decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public IEnumerable<RoomTypeEntity> RoomTypes { get; set; } = new List<RoomTypeEntity>();
    }
}
