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
            var roomModel = await roomService.GetRoomDetailsAsync(id);

            return View(roomModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, RoomFormModel model)
        {
            var result = await roomService.EditRoomAsync(id, model);

            return RedirectToAction("Index", "Room");
        }
    }
}
