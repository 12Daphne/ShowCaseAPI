using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using showcaseAPI.Data;
using showcaseAPI.Migrations;
using showcaseAPI.Models;

namespace showcaseAPI.Controllers
{

    public class RoomUpdate()
    {
        public int Id { get; set; }
        public string UserName { get; set;}
        public bool Owner {  get; set; }
    }

    public class RoomGetter()
    {

        public List<String> UserNames { get; set; }
        public int Owner { get; set; }
       
    }
    [Route("api/[controller]")]
    [ApiController]
    public class ArtRoomController : ControllerBase
    {
        DbController context;
        public ArtRoomController(DbController context)
        {
            this.context = context;
        }
        [HttpGet("{id}")]
        public RoomGetter Get(int id)
        {
              var room = context.users
                .Where(u => u.RoomId == id)
                .Select(u => u.UserName)
                .ToList();
            var owner = context.rooms.Where(u => u.Id == id).Select(u => u.OwnerId).FirstOrDefault();
            if (room == null || owner == null) return null;
            RoomGetter roomGetter = new();
            roomGetter.UserNames = room;
            roomGetter.Owner = owner;
            return roomGetter;

        }

        [HttpPost]
        public IActionResult post([FromBody] RoomUpdate roomup)
        {
            var user = context.users
            .Where(b => b.UserName == roomup.UserName)
                    .FirstOrDefault();
            if (user == null) return NotFound();

            var room = context.rooms
                .Where(b => b.Id == roomup.Id)
                .FirstOrDefault();

            var lastroom = context.rooms
                .Where(b => b.Id == user.RoomId).FirstOrDefault();


            if (room == null) return NotFound();
            user.Room = room;


            context.rooms.Update(room);
            context.users.Update(user);
            context.SaveChanges();

            return Ok();
        }


    }
}
