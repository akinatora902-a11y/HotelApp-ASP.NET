using HotelApp.Common.Contract;
using HotelApp.Corе.Contracts;
using HotelApp.Corе.DataTransferObjects;
using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp_ASP.NET.ViewModels.BookingsModels;
using Microsoft.EntityFrameworkCore;
using static HotelApp.Common.ValidationConstants.AppValidation;

namespace HotelApp.Corе.Services
{
    public class BookingService(HotelDbContext dbContext, IValidationService validationService) : IBookingService
    {
        public async Task<IEnumerable<BookingIndexViewModel>> AllBookingAsync()
        {
            try
            {
                var allBookings = await dbContext.Bookings
                    .OrderBy(b => b.Id)
                    .ThenBy(b => b.RoomId)
                    .Select(b => new BookingIndexViewModel()
                    {
                        Id = b.Id,
                        GuestName = b.GuestName,
                        GuestEmail = b.GuestEmail,
                        GuestPhone = b.GuestPhone,
                        CheckInDate = b.CheckInDate.ToString(DateFormat),
                        CheckOutDate = b.CheckOutDate.ToString(DateFormat),
                        TotalPrice = b.TotalPrice,
                        RoomNumber = b.Room.RoomNumber,
                    })
                    .Take(EntityPerPages)
                    .ToArrayAsync();

                if (!await validationService.HasAnyAsync(allBookings))
                {
                    return Enumerable.Empty<BookingIndexViewModel>();
                }

                return allBookings;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while retrieving the bookings.", ex);
            }
        }

        public async Task<bool> CreateBookingAsync(BookingFormModel model)
        {
            try
            {
                if (!await validationService.IsValidIdAsync(model.RoomId))
                {
                    return false;
                }

                if (!await validationService.IsNotNullOrWhiteSpaceAsync(model.GuestName) ||
                    !await validationService.IsNotNullOrWhiteSpaceAsync(model.GuestEmail) ||
                    !await validationService.IsNotNullOrWhiteSpaceAsync(model.GuestPhone))
                {
                    return false;
                }

                var room = await dbContext.Rooms.FirstOrDefaultAsync(r => r.Id == model.RoomId);

                if (!await validationService.ExistsAsync(room))
                {
                    return false;
                }

                var totalDays = (model.CheckOutDate - model.CheckInDate).Days;
                var roomPrice = await dbContext.Rooms
                    .Where(r => r.Id == model.RoomId)
                    .Select(r => r.RoomType.PricePerNight)
                    .FirstOrDefaultAsync();

                var newBooking = new BookingEntity()
                {
                    GuestName = model.GuestName,
                    GuestEmail = model.GuestEmail,
                    GuestPhone = model.GuestPhone,
                    RoomId = model.RoomId,
                    CheckInDate = model.CheckInDate,
                    CheckOutDate = model.CheckOutDate,
                    TotalPrice = totalDays * roomPrice
                };

                dbContext.Bookings.Add(newBooking);
                room.IsAvailable = false;
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while creating the booking.", ex);
            }
        }

        public async Task<BookingDetailsViewModel> DetailAsync(int id)
        {
            try
            {
                if (!await validationService.IsValidIdAsync(id))
                {
                    return null;
                }

                var details = await dbContext.Bookings
                    .Where(b => b.Id == id)
                    .Select(d => new BookingDetailsViewModel()
                    {
                        Id = d.Id,
                        GuestName = d.GuestName,
                        GuestEmail = d.GuestEmail,
                        GuestPhone = d.GuestPhone,
                        CheckInDate = d.CheckInDate.ToString(DateFormat),
                        CheckOutDate = d.CheckOutDate.ToString(DateFormat),
                        TotalPrice = d.TotalPrice,
                        RoomNumber = d.Room.RoomNumber,
                        RoomTypeName = d.Room.RoomType.Name
                    })
                    .FirstOrDefaultAsync();

                if (!await validationService.ExistsAsync(details))
                {
                    return null;
                }

                return details;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while retrieving the booking details.", ex);
            }
        }

        public async Task<BookingFormModel> CreateFormModelAsync()
        {
            try
            {
                var addBookingForm = new BookingFormModel()
                {
                    CheckInDate = DateTime.Today,
                    CheckOutDate = DateTime.Today.AddDays(1),
                    Rooms = await AvailableRoomsAsync()
                };

                return addBookingForm;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while preparing the booking form.", ex);

            }
        }

        public async Task<IEnumerable<AvailableRoomsDropdown>> AvailableRoomsAsync()
        {
            try
            {
                var roomsList = await dbContext.Rooms
                    .Where(r => r.IsAvailable)
                    .Select(r => new AvailableRoomsDropdown
                    {
                        Id = r.Id,
                        RoomType = r.RoomType.Name
                    })
                    .ToListAsync();

                if (!await validationService.HasAnyAsync(roomsList))
                {
                    return Enumerable.Empty<AvailableRoomsDropdown>();
                }

                return roomsList;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while retrieving the available rooms.", ex);
            }
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            try
            {
                if (!await validationService.IsValidIdAsync(id))
                {
                    return false;
                }

                var deleteBooking = await dbContext.Bookings.FindAsync(id);
                if (!await validationService.ExistsAsync(deleteBooking))
                {
                    return false;
                }

                var room = await dbContext.Rooms.FindAsync(deleteBooking.RoomId);
                if (await validationService.ExistsAsync(room))
                {
                    room.IsAvailable = true;
                }

                dbContext.Bookings.Remove(deleteBooking);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while deleting the booking.", ex);
            }
        }

    }
}
