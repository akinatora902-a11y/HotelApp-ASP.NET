using HotelApp.Corе.Contracts;
using HotelApp.Data;
using HotelApp_ASP.NET.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Corе.Services
{
    public class TypeService (HotelDbContext dbContext) : ITypeService
    {
        public IEnumerable<DropdownRoomType> allRoomTypes()
        {
            var allRoomTypes = dbContext.RoomTypes
                .Select(allt => new DropdownRoomType()
                {
                    Id = allt.Id,
                    Name = allt.Name,
                })
                .OrderBy(t => t.Name)
                .ToArray();

            return allRoomTypes;
        }
    }
}
