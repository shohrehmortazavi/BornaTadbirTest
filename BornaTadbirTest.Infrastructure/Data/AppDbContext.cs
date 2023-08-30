using BornaTadbirTest.Domain.Entities.BuyTransactions;
using BornaTadbirTest.Domain.Entities.Persons;
using BornaTadbirTest.Infrastructure.Entities.BuyTransactions;
using BornaTadbirTest.Infrastructure.Entities.Persons;
using Microsoft.EntityFrameworkCore;

namespace BornaTadbirTest.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<BuyTransaction> BuyTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Person>();
            modelBuilder.Entity<BuyTransaction>();


            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new BuyTransactionConfiguration());

        }
    }
}
