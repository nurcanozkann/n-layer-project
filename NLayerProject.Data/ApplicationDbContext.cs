using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Entity;
using NLayerProject.Data.Configuration;
using NLayerProject.Data.Seed;

namespace NLayerProject.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Person> Persons { get; set; }

        //tablolar oluışmadan önce oluşacak metod
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));

            //üstekilerden farklı bir kullanım için burada oluşturuldu.
            modelBuilder.Entity<Person>().HasKey(x=>x.Id);
            modelBuilder.Entity<Person>().Property(x=>x.Id).UseIdentityColumn();
            modelBuilder.Entity<Person>().Property(x=>x.Name).HasMaxLength(100);
            modelBuilder.Entity<Person>().Property(x=>x.Surname).HasMaxLength(100);
        }
    }
}
