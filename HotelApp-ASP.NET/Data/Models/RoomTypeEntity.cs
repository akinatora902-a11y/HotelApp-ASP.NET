namespace HotelApp_ASP.NET.Data.Models
{
    public class RoomTypeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public string Description { get; set; }

        public virtual ICollection<RoomEntity> Rooms { get; set; } = new HashSet<RoomEntity>();
    }
}
