using HotelApp_ASP.NET.ViewModels;

namespace HotelApp.Corе.Contracts
{
    public interface ITypeService
    {
        public IEnumerable<DropdownRoomType> allRoomTypes();
    }
}
