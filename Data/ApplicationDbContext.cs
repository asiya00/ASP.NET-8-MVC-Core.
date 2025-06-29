using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ecommerce.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, CategoryName = "Action", DisplayOrder = 1 },
                new Category { ID = 2, CategoryName = "Horror", DisplayOrder = 2 },
                new Category { ID = 3, CategoryName = "Thriller", DisplayOrder = 3 }
                );
        }
    }
}
