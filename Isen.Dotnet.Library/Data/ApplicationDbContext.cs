using Isen.Dotnet.Library.Models.Implementation;
using Microsoft.EntityFrameworkCore;

namespace Isen.Dotnet.Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        // 1 - Préciser les DbSet
        public DbSet<City> CityCollection { get;set; }
        public DbSet<Person> PersonCollection { get;set; }

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(
            ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // 2 - Configurer les mappings tables / classes
            builder.Entity<City>()
                .ToTable("City")
                .HasMany(c=> c.PersonCollection)
                .WithOne(p=> p.city)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Person>()
                .ToTable("Person") 
                .HasOne(p => p.city)
                .WithMany(c => c.PersonCollection)
                .HasForeignKey(p => p.cityId) ;
        }
    }

}