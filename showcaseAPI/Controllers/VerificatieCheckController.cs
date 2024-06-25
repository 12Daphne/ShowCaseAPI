using Microsoft.AspNetCore.Mvc;
using showcaseAPI.Data;
using System.Net.Mail;
using System.Net;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Net.Http.Headers;

namespace showcaseAPI.Controllers
{

    public class Code
    {
        public string Email { get; set; }
        public int Codecode { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class VerificatieCheckController : ControllerBase
    {

        private DbController context;
        public VerificatieCheckController(DbController controller)
        {
            context = controller;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Code code)
        {
            string emailWithoutQuotes = code.Email.Trim('"');
            var user = context.users
            .Where(b => b.Email == emailWithoutQuotes)
                    .FirstOrDefault();
   
            if (user == null) return NotFound();
            Console.WriteLine("hey");
            long timeNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
       
            if (timeNow - user.LastVerify >= 5 * 60) return NotFound();

            if(user.Verify != code.Codecode) return BadRequest();
            String token = GenerateJwtToken(user.UserName);

      
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Expires = DateTime.Now.AddDays(1);
            cookieOptions.Domain = "localhost";
            cookieOptions.Path = "/";
            cookieOptions.Secure = false;
            
            //cookieOptions.HttpOnly = true;
            Response.Cookies.Append("token", token, cookieOptions);
            //HttpContext.Response.Cookies.Append("token", token, cookieOptions);

            return Ok();
        }
        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("stitch-is-soeper-cool--j--j-j--j-j"); 
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
