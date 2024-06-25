using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using showcaseAPI.Data;
using showcaseAPI.Models;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;

namespace showcaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {

        private DbController context;
        public EmailController(DbController controller)
        {
            context = controller;
        }

        [HttpPost]
        public bool Post([FromBody] String email)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(10000, 100000);

            var user = context.users
            .Where(b => b.Email == email)
                    .FirstOrDefault();
            if (user == null) return false;

            user.Verify = randomNumber;
            user.LastVerify = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            context.users.Update(user);
            context.SaveChanges();
            //return true; // change wnr je weer mails mag sturen 
            try
            {
                var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
                {
                    Credentials = new NetworkCredential("c65c036681b65d", "cdf93a555b1d96"),
                    EnableSsl = true
                };

                client.Send("verificatie@gmail.com", email, "verificatie", "Your code is: " +  randomNumber);
                System.Console.WriteLine("Sent");

                return true;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
