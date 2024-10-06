using CQRS_Implementation.Domain;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Implementation.DataAccess
{
    public sealed class DemoAppDbContext: DbContext
    {
        public DemoAppDbContext(DbContextOptions<DemoAppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(p => p.Id);
            modelBuilder.Entity<User>().HasData(
                new User(1,"Lithisha", "lithisha@xxx.com","INAKQ2"),
                new User(2, "Keerthi Vasan", "keerthivasan@xxx.com", "KVRKS5")
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("DemoAppDB");
        }
    }
}
