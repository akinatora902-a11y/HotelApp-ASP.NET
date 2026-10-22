using HotelApp.Corе.Contracts;
using HotelApp_ASP.NET.ViewModels.BookingsModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp_ASP.NET.Controllers
{
    public class BookingController(IBookingService bookingService) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allBookings = await bookingService.AllBookingAsync();

            return View(allBookings);
        }

        [HttpGet]
        public async Task<IActionResult> Details (int Id)
        {

            var details = await bookingService.DetailAsync(Id);

            return View(details);
        }
        
        [HttpGet] 
        public async Task<IActionResult> Create()
        {
            var addBokingform = await bookingService.CreateFormModelAsync();

            return View(addBokingform);
        }

        [HttpPost]
        public async Task<IActionResult> Create (BookingFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool isCreated = await bookingService.CreateBookingAsync(model);

            if (!isCreated)
            {
                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await bookingService.DetailAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool delete = await bookingService.DeleteBookingAsync(id);

            if (!delete)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
