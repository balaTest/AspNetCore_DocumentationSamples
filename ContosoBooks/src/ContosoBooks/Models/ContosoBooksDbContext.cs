using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoBooks.Models;

namespace ContosoBooks.Models
{
    public class ContosoBooksDbContext : DbContext
    {
        public ContosoBooksDbContext (DbContextOptions<ContosoBooksDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Author> Author { get; set; }
    }
}
