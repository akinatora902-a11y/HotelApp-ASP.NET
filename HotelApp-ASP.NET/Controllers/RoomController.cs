using HotelApp.Corе.Contracts;
using HotelApp.Corе.Services;
using HotelApp_ASP.NET.ViewModels.RoomsModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp_ASP.NET.Controllers
{
    public class RoomController(IRoomService roomService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var AllRoom = await roomService.AllRoomAsync();

            return View(AllRoom);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            var detailsForRoom = await roomService.GetRoomDetailsAsync(id);

            return View(detailsForRoom);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var roomModel = await roomService.GetRoomForEditAsync(id);

            return View(roomModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RoomFormModel model)
        {
            var result = await roomService.EditRoomAsync(id, model);

            return RedirectToAction("Index", "Room");
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
            var newRoom = roomService.CreateRoomAsync(model);

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool delete = await roomService.DeleteRoomAsync(id);

            if (!delete)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
