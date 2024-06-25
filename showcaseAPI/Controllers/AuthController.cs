using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using showcaseAPI.Data;
using showcaseAPI.Migrations;
using showcaseAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace showcaseAPI.Controllers
{
    public class ClientUser()
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public int? RoomsId { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public DbController context {  get; set; }
        public AuthController(DbController context)
        {
            this.context = context;
        }
        [HttpGet]
        public ClientUser Get()
        {
            string cookieValue = Request.Cookies["token"];
            Console.WriteLine(cookieValue);
            if (cookieValue == null) { return null; }
            string username = DecodeJwtToken(cookieValue);
            Console.WriteLine(username);
            var user = context.users
            .Where(b => b.UserName == username)
                    .FirstOrDefault();
            if (user == null) return null;
            Console.WriteLine("Gevonden!");
            return new ClientUser
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                UserName = username,
                RoomsId = user.RoomId
            };
        }

        private string DecodeJwtToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("stitch-is-soeper-cool--j--j-j--j-j"); 

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            SecurityToken validatedToken;
            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtToken, tokenValidationParameters, out validatedToken);

            var username = claimsPrincipal.Identity.Name;
            return username;
        }
    }
}
