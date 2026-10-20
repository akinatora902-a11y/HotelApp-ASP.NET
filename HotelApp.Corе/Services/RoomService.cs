using HotelApp.Corе.Contracts;
using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp_ASP.NET.ViewModels.RoomsModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static HotelApp.Common.ValidationConstants.AppValidation;
namespace HotelApp.Corе.Services
{
    public class RoomService(HotelDbContext dbContext) : IRoomService
    {
        public IEnumerable<RoomIndexViewModel> AllRoom()
        {
            var roomList = dbContext.Rooms
                .OrderBy(r => r.Id)
                .Select(r => new RoomIndexViewModel
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomTypeName = r.RoomType.Name,
                    Floor = r.Floor,
                    PricePerNight = r.PricePerNight,
                    IsAvailable = r.IsAvailable,
                })
                .Take(EntityPerPages)
                .ToArray();

            return roomList;
        }

        public bool EditRoom(int id, RoomFormModel editModel)
        {
            var roomToEdit = dbContext.Rooms.Find(id);

            roomToEdit.RoomNumber = editModel.RoomNumber;
            roomToEdit.Floor = editModel.Floor;
            roomToEdit.PricePerNight = editModel.PricePerNight;
            roomToEdit.IsAvailable = editModel.IsAvailable;
            roomToEdit.RoomTypeId = editModel.RoomTypeId;

            dbContext.SaveChanges();

            return true;
        }

        public RoomDetailsViewModel GetRoomDetails(int id)
        {
            var roomDetails = dbContext.Rooms
                .Where(r => r.Id == id)
                .Select(r => new RoomDetailsViewModel
                {
                    RoomNumber = r.RoomNumber,
                    Floor = r.Floor,
                    PricePerNight = r.PricePerNight,
                    IsAvailable = r.IsAvailable,
                    RoomTypeName = r.RoomType.Name,
                    Description = r.RoomType.Description,
                    Capacity = r.RoomType.Capacity

                })
                .FirstOrDefault();

            return roomDetails;
        }

        public RoomFormModel GetRoomForEdit(int id)
        {
            var roomToEdit = dbContext.Rooms.Find(id);

            return new RoomFormModel()
            {
                RoomNumber = roomToEdit.RoomNumber,
                Floor = roomToEdit.Floor,
                PricePerNight = roomToEdit.PricePerNight,
                IsAvailable = roomToEdit.IsAvailable,
                RoomTypeId = roomToEdit.RoomTypeId,
                RoomTypes = dbContext.RoomTypes
            .Select(rt => new RoomTypeEntity()
            {
                Id = rt.Id,
                Name = rt.Name
            })
            .ToList()
            };
        }
    }
}
