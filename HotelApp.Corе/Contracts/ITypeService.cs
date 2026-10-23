using HotelApp_ASP.NET.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Corе.Contracts
{
    public interface ITypeService
    {
        public IEnumerable<DropdownRoomType> allRoomTypes();
    }
}
