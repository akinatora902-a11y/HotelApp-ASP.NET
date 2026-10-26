using HotelApp.Corе.Contracts;
using HotelApp_ASP.NET.ViewModels.RoomsModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp_ASP.NET.Controllers
{
    public class RoomController(IRoomService roomService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allRooms = await roomService.AllRoomAsync();

            return View(allRooms);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailsForRoom = await roomService.GetRoomDetailsAsync(id);

            if (detailsForRoom == null)
            {
                return NotFound();
            }

            return View(detailsForRoom);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var roomModel = await roomService.GetRoomForEditAsync(id);

            if (roomModel == null)
            {
                return NotFound();
            }

            return View(roomModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RoomFormModel model)
        {
            if (!ModelState.IsValid)
            {
                var form = await roomService.CreateFormAsync();
                model.RoomTypes = form.RoomTypes;

                return View(model);
            }

            var result = await roomService.EditRoomAsync(id, model);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roomCreateForm = await roomService.CreateFormAsync();

            return View(roomCreateForm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomFormModel model)
        {
            if (!ModelState.IsValid)
            {
                var form = await roomService.CreateFormAsync();
                model.RoomTypes = form.RoomTypes;

                return View(model);
            }

            var result = await roomService.CreateRoomAsync(model);

            if (!result)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await roomService.GetRoomDetailsAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(RoomDetailsViewModel model)
        {
            bool deleted = await roomService.DeleteRoomAsync(model.Id);

            if (!deleted)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
