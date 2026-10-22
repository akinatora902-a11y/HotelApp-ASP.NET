using HotelApp.Corе.DataTransferObjects;
using HotelApp_ASP.NET.ViewModels.BookingsModels;

namespace HotelApp.Corе.Contracts
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingIndexViewModel>> AllBookingAsync();
        Task<BookingDetailsViewModel> DetailAsync(int id);
        Task<BookingFormModel> CreateFormModelAsync();
        Task<bool> CreateBookingAsync(BookingFormModel model);
        Task<IEnumerable<AvailableRoomsDropdown>> AvailableRoomsAsync();
        Task<bool> DeleteBookingAsync(int id);
    }
}
