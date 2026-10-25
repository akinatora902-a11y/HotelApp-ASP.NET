using HotelApp.Common.Contract;
using HotelApp.Corе.Contracts;
using HotelApp.Data;
using HotelApp.Data.Models;
using HotelApp_ASP.NET.ViewModels;
using HotelApp_ASP.NET.ViewModels.RoomsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static HotelApp.Common.ValidationConstants.AppValidation;
namespace HotelApp.Corе.Services
{
    public class RoomService(HotelDbContext dbContext, IValidationService validationService, ITypeService typeService) : IRoomService
    {
        public async Task<IEnumerable<RoomIndexViewModel>> AllRoomAsync()
        {
            try
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
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while retrieving the rooms.", ex);
            }
        }

        public async Task<RoomFormModel> CreateFormAsync()
        {
            try
            {
                var room = new RoomFormModel()
                {
                    RoomTypes = typeService.allRoomTypes()
                };

                return room;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while preparing the room form.", ex);
            }
        }

        public async Task<bool> CreateRoomAsync(RoomFormModel model)
        {
            try
            {
                var newRoom = new RoomEntity()
                {
                    RoomNumber = model.RoomNumber,
                    Floor = model.Floor,
                    IsAvailable = model.IsAvailable,
                    RoomTypeId = model.RoomTypeId,
                };

                dbContext.Rooms.Add(newRoom);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while creating the room.", ex);
            }
        }

        public async Task<bool> EditRoomAsync(int id, RoomFormModel editModel)
        {
            try
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
                roomToEdit.IsAvailable = editModel.IsAvailable;
                roomToEdit.RoomTypeId = editModel.RoomTypeId;

                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while editing the room.", ex);
            }
        }

        public async Task<RoomDetailsViewModel> GetRoomDetailsAsync(int id)
        {
            try
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
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while retrieving the room details.", ex);
            }
        }

        public async Task<RoomFormModel> GetRoomForEditAsync(int id)
        {
            try
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

                var roomModel = new RoomFormModel()
                {
                    RoomNumber = roomToEdit.RoomNumber,
                    Floor = roomToEdit.Floor,
                    IsAvailable = roomToEdit.IsAvailable,
                    RoomTypeId = roomToEdit.RoomTypeId,
                    RoomTypes = typeService.allRoomTypes()
                };

                return roomModel;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while retrieving the room for editing.", ex);
            }
        }

        public async Task<bool> DeleteRoomAsync(int id)
        {
            try
            {
                if (!await validationService.IsValidIdAsync(id))
                {
                    return false;
                }

                var room = await dbContext.Rooms.FindAsync(id);
                if (!await validationService.ExistsAsync(room))
                {
                    return false;
                }

                dbContext.Rooms.Remove(room);
                await dbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("An error occurred while deleting the room.", ex);
            }
        }
    }
}

