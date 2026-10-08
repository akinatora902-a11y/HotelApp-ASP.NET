namespace HotelApp_ASP.NET.ViewModels.RoomsModels
{
    public class RoomIndexViewModel
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public int Floor {  get; set; }
        decimal PricePerNight { get; set; }
        public bool IsAvailable { get; set; }
        public string RoomTypeName { get; set; }
    }
}
