using HotelApp.Common.Contract;
using HotelApp.Corе.Contracts;
using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp_ASP.NET.ViewModels.RoomsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static HotelApp.Common.ValidationConstants.AppValidation;
namespace HotelApp.Corе.Services
{
    public class RoomService(HotelDbContext dbContext, IValidationService validationService) : IRoomService
    {
        public async Task<IEnumerable<RoomIndexViewModel>> AllRoomAsync()
        {
            var roomList = await dbContext.Rooms
                .OrderBy(r => r.Id)
                .Select(r => new RoomIndexViewModel
                {
                    Id = r.Id,
                    RoomNumber = r.RoomNumber,
                    RoomTypeName = r.RoomType.Name,
                    Floor = r.Floor,
                    PricePerNight = r.RoomType.PricePerNight,
                    IsAvailable = r.IsAvailable,
                })
                .Take(EntityPerPages)
                .ToArrayAsync();

            if (!await validationService.HasAnyAsync(roomList))
            {
                return Enumerable.Empty<RoomIndexViewModel>();
            }

            return roomList;
        }
        public async Task<bool> EditRoomAsync(int id, RoomFormModel editModel)
        {
            if (!await validationService.IsValidIdAsync(id))
            {
                return false;
            }

            var roomToEdit = await dbContext.Rooms.FindAsync(id);

            if (!await validationService.ExistsAsync(roomToEdit))
            {
                return false;
            }

            roomToEdit.RoomNumber = editModel.RoomNumber;
            roomToEdit.Floor = editModel.Floor;
            roomToEdit.RoomType.PricePerNight = editModel.PricePerNight;
            roomToEdit.IsAvailable = editModel.IsAvailable;
            roomToEdit.RoomTypeId = editModel.RoomTypeId;

            await dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<RoomDetailsViewModel> GetRoomDetailsAsync(int id)
        {
            if (!await validationService.IsValidIdAsync(id))
            {
                return null;
            }

            var roomDetails = await dbContext.Rooms
                .Where(r => r.Id == id)
                .Select(r => new RoomDetailsViewModel
                {
                    RoomNumber = r.RoomNumber,
                    Floor = r.Floor,
                    PricePerNight = r.RoomType.PricePerNight,
                    IsAvailable = r.IsAvailable,
                    RoomTypeName = r.RoomType.Name,
                    Description = r.RoomType.Description,
                    Capacity = r.RoomType.Capacity
                })
                .FirstOrDefaultAsync();

            if (!await validationService.ExistsAsync(roomDetails))
            {
                return null;
            }

            return roomDetails;
        }
        public async Task<RoomFormModel> GetRoomForEditAsync(int id)
        {
            if (!await validationService.IsValidIdAsync(id))
            {
                return null;
            }

            var roomToEdit = await dbContext.Rooms.FindAsync(id);

            if (!await validationService.ExistsAsync(roomToEdit))
            {
                return null;
            }

            return new RoomFormModel()
            {
                RoomNumber = roomToEdit.RoomNumber,
                Floor = roomToEdit.Floor,
                PricePerNight = roomToEdit.RoomType.PricePerNight,
                IsAvailable = roomToEdit.IsAvailable,
                RoomTypeId = roomToEdit.RoomTypeId,
                RoomTypes = await dbContext.RoomTypes
                    .Select(rt => new RoomTypeEntity()
                    {
                        Id = rt.Id,
                        Name = rt.Name
                    })
                    .ToListAsync()
            };
        }
    }
}

