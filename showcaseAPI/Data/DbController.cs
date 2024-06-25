using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using showcaseAPI.Models;

namespace showcaseAPI.Data
{
    public class DbController : DbContext
    {
        public DbController(DbContextOptions options) :base(options){ }

        public DbSet<Users> users { get; set; }
        public DbSet<Rooms> rooms { get; set; }

    }
}
