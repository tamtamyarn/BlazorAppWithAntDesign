using BlazorAppWithAntDesign.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppWithAntDesign.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
