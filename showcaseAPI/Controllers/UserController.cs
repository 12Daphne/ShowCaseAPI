using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using showcaseAPI.Data;
using showcaseAPI.Models;

namespace showcaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private DbController context;
        public UserController(DbController controller)
        {
            context = controller;
        }

        [HttpPost]
        public bool Post([FromBody] Users users)
        {
            if (ModelState.IsValid)
            {
                var name = context.users
                    .Where(b => b.UserName == users.UserName || b.Email == users.Email)
                    .FirstOrDefault();
                if (name != null) return false;
                if (string.IsNullOrEmpty(users.UserName)) return false; 
                if (string.IsNullOrEmpty(users.Name)) return false; 
                if (string.IsNullOrEmpty(users.Email)) return false; 
                if (string.IsNullOrEmpty(users.Password)) return false; 

                Users user = new Users()
                {
                    UserName = users.UserName,
                    Name = users.Name,
                    Email = users.Email,
                    Password = users.Password,
                };

                context.users.Add(user);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
