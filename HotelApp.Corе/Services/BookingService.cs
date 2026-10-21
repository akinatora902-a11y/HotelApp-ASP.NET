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
        public IEnumerable<BookingIndexViewModel> AllBooking()
        {
            var allBookings = dbContext.Bookings
               .OrderBy(b => b.Id)
               .ThenBy(b => b.RoomId)
               .Include(r => r.Room)
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
               .ToArray();

            if (!validationService.HasAny(allBookings))
            {
                return Enumerable.Empty<BookingIndexViewModel>();
            }

            return allBookings;
        }

        public bool CreateBooking(BookingFormModel model)
        {
            var room = dbContext.Rooms.FirstOrDefault(r => r.Id == model.RoomId);
            if (!validationService.Exists(room))
            {
                return false;
            }

            var totalDays = (model.CheckOutDate - model.CheckInDate).Days;
            var roomPrice = dbContext.Rooms
                .Where(r => r.Id == model.RoomId)
                .Select(r => r.PricePerNight)
                .FirstOrDefault();

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
            dbContext.SaveChanges();

            return true;
        }

        public BookingDetailsViewModel Detail(int id)
        {
            if (!validationService.IsValidId(id))
            {
                return null;
            }

            var details = dbContext.Bookings
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
                .FirstOrDefault();

            if (!validationService.Exists(details))
            {
                return null;
            }

            return details;
        }

        public BookingFormModel CreateFormModel()
        {
            var addBookingForm = new BookingFormModel()
            {
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(1),
                Rooms = availableRooms()
            };

            return addBookingForm;
        }

        public IEnumerable<AvailableRoomsDropdown> availableRooms()
        {
            var roomsList = dbContext.Rooms
                .Include(r => r.RoomType)
                .Where(r => r.IsAvailable)
                .Select(r => new AvailableRoomsDropdown
                {
                    Id = r.Id,
                    RoomType = r.RoomType.Name
                })
                .ToList();

            if (!validationService.HasAny(roomsList))
            {
                return Enumerable.Empty<AvailableRoomsDropdown>();
            }

            return roomsList;
        }

        public bool DeleteBooking(int id)
        {
            if (!validationService.IsValidId(id))
            {
                return false;
            }

            var deleteBooking = dbContext.Bookings.Find(id);
            if (!validationService.Exists(deleteBooking))
            {
                return false;
            }

            var room = dbContext.Rooms.Find(deleteBooking.RoomId);
            if (validationService.Exists(room))
            {
                room.IsAvailable = true;
            }

            dbContext.Bookings.Remove(deleteBooking);
            dbContext.SaveChanges();

            return true;
        }



        //public IEnumerable<DropdownRoomType> allRoomTypes()
        //{
        //    var allRoomTypes = dbContext.RoomTypes
        //        .Select(alt => new DropdownRoomType()
        //        {
        //            Id = alt.Id,
        //            Name = alt.Name,
        //        })
        //        .OrderBy(t => t.Name)
        //        .ToArray();

        //    return allRoomTypes;
        //}
    }
}
