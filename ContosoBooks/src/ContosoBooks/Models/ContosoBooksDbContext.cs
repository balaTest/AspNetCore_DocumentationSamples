using Microsoft.Data.Entity;
using ContosoBooks.Models;

namespace ContosoBooks.Models
{
    public class ContosoBooksDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }
    }
}
