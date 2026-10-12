using HotelApp_ASP.NET.Data;
using HotelApp_ASP.NET.Data.Models;
using HotelApp_ASP.NET.ValidationConstants;
using HotelApp_ASP.NET.ViewModels;
using HotelApp_ASP.NET.ViewModels.BookingsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp_ASP.NET.Controllers
{
    public class BookingController : Controller
    {
        public readonly HotelDbContext dbContext;
        public BookingController(HotelDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
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

            return View(allBookings);
        }

        [HttpGet]
        public IActionResult Details (int Id)
        {

            var details = dbContext.Bookings
                .Where(b => b.Id == Id)
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

            return View(details);
        }
        
        [HttpGet] 
        public IActionResult Create()
        {
            var addBokingform = new BookingFormModel()
            {
                CheckInDate = DateTime.Today,
                CheckOutDate= DateTime.Today.AddDays(1),
                RoomType = allRoomTypes()
            };
            return View(addBokingform);
        }

        [HttpPost]
        public IActionResult Create (BookingFormModel model)
        {
            bool roomIsExist = dbContext.Rooms
                .Any(r  => r.Id == model.RoomId);

            if (!roomIsExist) 
            {
                return BadRequest();
            }

            try
            {
                BookingEntity newBooking = new BookingEntity()
                {
                    GuestName = model.GuestName,
                    GuestEmail = model.GuestEmail,
                    GuestPhone = model.GuestPhone,
                    RoomId = model.RoomId,
                    CheckInDate = model.CheckInDate,
                    CheckOutDate = model.CheckOutDate,
                };

                dbContext.Bookings.Add(newBooking);
                dbContext.SaveChanges();
            }
            catch (Exception ex) { }


            return View(nameof(Index));
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
    }
}
