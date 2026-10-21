using HotelApp.Common.Contract;
using HotelApp.Corе.Contracts;
using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp_ASP.NET.ViewModels.RoomsModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static HotelApp.Common.ValidationConstants.AppValidation;
namespace HotelApp.Corе.Services
{
    public class RoomService(HotelDbContext dbContext, IValidationService validationService) : IRoomService
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

            if (!validationService.HasAny(roomList))
            {
                return Enumerable.Empty<RoomIndexViewModel>();
            }

            return roomList;
        }

        public bool EditRoom(int id, RoomFormModel editModel)
        {
            if (!validationService.IsValidId(id))
            {
                return false;
            }

            var roomToEdit = dbContext.Rooms.Find(id);

            if (!validationService.Exists(roomToEdit))
            {
                return false;
            }

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
            if (!validationService.IsValidId(id))
            {
                return null;
            }

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

            if (!validationService.Exists(roomDetails))
            {
                return null;
            }

            return roomDetails;
        }

        public RoomFormModel GetRoomForEdit(int id)
        {
            if (!validationService.IsValidId(id))
            {
                return null;
            }

            var roomToEdit = dbContext.Rooms.Find(id);

            if (!validationService.Exists(roomToEdit))
            {
                return null;
            }

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
