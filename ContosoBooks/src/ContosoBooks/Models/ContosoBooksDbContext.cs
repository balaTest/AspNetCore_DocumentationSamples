using Microsoft.Data.Entity;
using ContosoBooks.Models;

namespace ContosoBooks.Models
{
    public class ContosoBooksDbContext : DbContext
    {
        private static bool _created = false;

        public ContosoBooksDbContext()
        {
            if (!_created)
            {
                _created = true;
                Database.EnsureCreated();
            }
        }

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
