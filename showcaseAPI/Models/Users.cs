namespace showcaseAPI.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int ?Verify {  get; set; }
        public long ?LastVerify { get; set; }

        public int? RoomId { get; set; }
        public Rooms? Room {  get; set; }

    }
}
