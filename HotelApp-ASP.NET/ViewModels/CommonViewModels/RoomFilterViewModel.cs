using HotelApp_ASP.NET.ViewModels.RoomsModels;

namespace HotelApp_ASP.NET.ViewModels.CommonViewModels
{
    public class RoomFilterViewModel
    {
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int? RoomTypeId { get; set; }
        public IEnumerable<RoomIndexViewModel> AvailableRooms { get; set; } = new List<RoomIndexViewModel>();
    }
}
