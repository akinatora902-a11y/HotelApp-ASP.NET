using HotelApp.Corе.DataTransferObjects;
using HotelApp_ASP.NET.ViewModels.BookingsModels;

namespace HotelApp.Corе.Contracts
{
    public interface IBookingService
    {
        IEnumerable<BookingIndexViewModel> AllBooking();
        BookingDetailsViewModel Detail(int id);
        BookingFormModel CreateFormModel ();
        bool CreateBooking(BookingFormModel model);
        public IEnumerable<AvailableRoomsDropdown> availableRooms();
        bool DeleteBooking (int id);
    }
}
