using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using showcaseAPI.Data;
using showcaseAPI.Models;

namespace showcaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private DbController context;
        public RoomController(DbController controller)
        {
            context = controller;
        }

        [HttpPost]
        public Rooms Post([FromBody] Rooms room)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(room.RoomName)) return null;

                Rooms roomobject = new Rooms()
                {
                    RoomName = room.RoomName,
                    RoomPassword = room.RoomPassword,
                    OwnerId = room.OwnerId,
                    OwnerName = room.OwnerName
                };

                context.rooms.Add(roomobject);
                context.SaveChanges();
                return roomobject;
            }

            return null;
        }


        [HttpGet]

        public IEnumerable<Rooms> Get()
        {
            return context.rooms;

        }
    }
}

