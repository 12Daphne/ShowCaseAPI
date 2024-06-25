using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using showcaseAPI.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace showcaseAPI.Controllers
{

    public class Inlog()
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class InlogController : ControllerBase
    {
        private DbController context;
        public InlogController(DbController controller) { 
            context = controller;
        }
        [HttpPost]
        public bool Post([FromBody] Inlog inlog)
        {
            Console.WriteLine(inlog.Email);
            var name = context.users
                    .Where(b => b.Password == inlog.Password && b.Email == inlog.Email)
                    .FirstOrDefault();
            if (name == null) return false;
            return true;
        }

    }
}
