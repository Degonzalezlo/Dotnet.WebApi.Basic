using Microsoft.EntityFrameworkCore;

namespace TODO.WebApi.Models
{
    public class TODOAppDbContext : DbContext
    {
        public TODOAppDbContext(DbContextOptions<TODOAppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; } 
        public DbSet<Review> Reviews { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Book>().ToTable("Books"); 
            modelBuilder.Entity<Review>().ToTable("Reviews");

            
        }
    }

}
