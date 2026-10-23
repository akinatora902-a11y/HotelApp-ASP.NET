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
        Task<IEnumerable<RoomIndexViewModel>> AllRoomAsync();
        Task<RoomDetailsViewModel> GetRoomDetailsAsync(int id);
        Task<RoomFormModel> GetRoomForEditAsync(int id);
        Task<bool> EditRoomAsync(int id, RoomFormModel editModel);
        Task<RoomFormModel> CreateFormAsync();
        Task<bool> CreateRoomAsync(RoomFormModel model);
        Task<bool> DeleteRoomAsync(int id);
    }
}
