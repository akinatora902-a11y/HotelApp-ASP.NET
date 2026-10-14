using HotelApp.Corе.Contracts;
using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp_ASP.NET.ValidationConstants;
using HotelApp_ASP.NET.ViewModels;
using HotelApp_ASP.NET.ViewModels.BookingsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Corе.Services
{
    public class BookingService(HotelDbContext dbContext) : IBookingService
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
                   CheckInDate = b.CheckInDate.ToString(AppValidation.DateTime),
                   CheckOutDate = b.CheckOutDate.ToString(AppValidation.DateTime),
                   TotalPrice = b.TotalPrice,
                   RoomNumber = b.Room.RoomNumber,
               })
               .Take(AppValidation.EntityPerPages)
               .ToArray();

            return allBookings;
        }

        public bool CreateBooking(BookingFormModel model)
        {
            bool roomIsExist = dbContext.Rooms.Any(r => r.Id == model.RoomId);
            if (!roomIsExist)
            {
                return false;
            }

            var newBooking = new BookingEntity()
            {
                GuestName = model.GuestName,
                GuestEmail = model.GuestEmail,
                GuestPhone = model.GuestPhone,
                RoomId = model.RoomId,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate
            };

            dbContext.Bookings.Add(newBooking);
            dbContext.SaveChanges();

            return true;
        }

        public BookingDetailsViewModel Detail(int id)
        {
            var details = dbContext.Bookings
                .Where(b => b.Id == id)
                .Select(d => new BookingDetailsViewModel()
                {
                    Id = d.Id,
                    GuestName = d.GuestName,
                    GuestEmail = d.GuestEmail,
                    GuestPhone = d.GuestPhone,
                    CheckInDate = d.CheckInDate.ToString(AppValidation.DateTime),
                    CheckOutDate = d.CheckOutDate.ToString(AppValidation.DateTime),
                    TotalPrice = d.TotalPrice,
                    RoomNumber = d.Room.RoomNumber,
                    RoomTypeName = d.Room.RoomType.Name
                })
                .FirstOrDefault();

            return details;
        }

        public IEnumerable<DropdownRoomType> allRoomTypes()
        {
            var allRoomTypes = dbContext.RoomTypes
                .Select(alt => new DropdownRoomType()
                {
                    Id = alt.Id,
                    Name = alt.Name,
                })
                .OrderBy(t => t.Name)
                .ToArray();

            return allRoomTypes;
        }

        public BookingFormModel CreateFormModel()
        {
            var addBokingform = new BookingFormModel()
            {
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(1),
                RoomType = allRoomTypes()
            };

            return addBokingform;
        }
    }
}
