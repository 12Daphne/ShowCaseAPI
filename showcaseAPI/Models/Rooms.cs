namespace showcaseAPI.Models
{
    public class Rooms
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string RoomName { get; set; }
        public string ?RoomPassword { get; set; }

        public ICollection<Users> ?Players { get; set; }
    }
}
