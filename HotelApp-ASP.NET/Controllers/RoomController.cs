using HotelApp.Corе.Contracts;
using HotelApp.Corе.Services;
using HotelApp_ASP.NET.ViewModels.RoomsModels;
using Microsoft.AspNetCore.Mvc;

namespace HotelApp_ASP.NET.Controllers
{
    public class RoomController(IRoomService roomService) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var AllRoom = roomService.AllRoom();

            return View(AllRoom);
        }

        [HttpGet]
        public IActionResult Details(int id) 
        {
            var detailsForRoom = roomService.GetRoomDetails(id);

            return View(detailsForRoom);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var roomModel = roomService.GetRoomForEdit(id);

            return View(roomModel);
        }

        [HttpPost]
        public IActionResult Edit(int id, RoomFormModel model)
        {
            bool result = roomService.EditRoom(id, model);

            return RedirectToAction("Index", "Room");
        }
    }
}
