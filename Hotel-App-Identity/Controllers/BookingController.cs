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
        public async Task<IActionResult> Details(int id)
        {
            var details = await bookingService.DetailAsync(id);

            if (details == null)
            {
                return NotFound();
            }

            return View(details);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var addBookingForm = await bookingService.CreateFormModelAsync();

            return View(addBookingForm);
        }

        [HttpPost]
        public async Task<IActionResult> Create (BookingFormModel model)
        {
            if (!ModelState.IsValid)
            {
                var form = await bookingService.CreateFormModelAsync();
                model.Rooms = form.Rooms;

                return View(model);
            }

            bool isCreated = await bookingService.CreateBookingAsync(model);

            if (!isCreated)
            {
                var form = await bookingService.CreateFormModelAsync();
                model.Rooms = form.Rooms;

                return View(model);
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
            bool deleted = await bookingService.DeleteBookingAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
