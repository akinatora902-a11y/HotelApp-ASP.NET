using HotelApp.Corе.Contracts;
using HotelApp.Corе.DataTransferObjects;
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
            var room = dbContext.Rooms.FirstOrDefault(r => r.Id == model.RoomId);
            if (room == null)
            {
                return false;
            }

            var totalDays = (model.CheckOutDate - model.CheckInDate).Days;

            var newBooking = new BookingEntity()
            {
                GuestName = model.GuestName,
                GuestEmail = model.GuestEmail,
                GuestPhone = model.GuestPhone,
                RoomId = model.RoomId,
                CheckInDate = model.CheckInDate,
                CheckOutDate = model.CheckOutDate,
                TotalPrice = totalDays * dbContext.Rooms.Where(r => r.Id == model.RoomId).Select(r => r.PricePerNight).FirstOrDefault(),
            };

            dbContext.Bookings.Add(newBooking);
            room.IsAvailable = false;
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

        public BookingFormModel CreateFormModel()
        {
            var addBokingform = new BookingFormModel()
            {
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today.AddDays(1),
                Rooms = availableRooms()
            };

            return addBokingform;
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

            return roomsList;
        }

        public bool DeleteBooking(int id)
        {
            var deleteBooking = dbContext.Bookings.Find(id);
            if (deleteBooking == null)
            {
                return false;
            }

            var room = dbContext.Rooms.Find(deleteBooking.RoomId);
            if (room != null) 
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
