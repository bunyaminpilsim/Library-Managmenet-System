using LibraryManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
