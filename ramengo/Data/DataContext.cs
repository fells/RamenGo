using Microsoft.EntityFrameworkCore;
using ramengo.Models;

namespace ramengo.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Broth> Broths { get; set; }
        public DbSet<Protein> Proteins { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Username=;" + // Place in your Username for the DB
                "Password=;" + // Place in your Password for the DB
                "Database=RamenGo;");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(p => p.Broth)
                .WithMany()
                .HasForeignKey(p => p.BrothId);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Protein)
                .WithMany()
                .HasForeignKey(p => p.ProteinId);
        }

    }
}
