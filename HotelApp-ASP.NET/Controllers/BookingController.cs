using HotelApp.Corе.Contracts;
using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp_ASP.NET.ValidationConstants;
using HotelApp_ASP.NET.ViewModels;
using HotelApp_ASP.NET.ViewModels.BookingsModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelApp_ASP.NET.Controllers
{
    public class BookingController(IBookingService bookingService) : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            var allBookings = bookingService.AllBooking();

            return View(allBookings);
        }

        [HttpGet]
        public IActionResult Details (int Id)
        {

            var details = bookingService.Detail(Id);

            return View(details);
        }
        
        [HttpGet] 
        public IActionResult Create()
        {
            var addBokingform = bookingService.CreateFormModel();

            return View(addBokingform);
        }

        [HttpPost]
        public IActionResult Create (BookingFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isCreated = bookingService.CreateBooking(model);

            if (!isCreated)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
