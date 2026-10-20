using HotelApp_ASP.NET.ViewModels.RoomsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Corе.Contracts
{
    public interface IRoomService
    {
        public IEnumerable<RoomIndexViewModel> AllRoom();

        public RoomDetailsViewModel GetRoomDetails(int id);

        public RoomFormModel GetRoomForEdit(int id);

        public bool EditRoom(int id, RoomFormModel editModel);
    }
}
