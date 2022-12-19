using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EFdbAquarium.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Aquarium> Aquariums { get; set; } = null!;
        public DbSet<Fish> Fishes { get; set; } = null!;
        public DbSet<Shrimp> Shrimps { get; set; } = null!;
        public DbSet<Food> Foods { get; set; } = null!;
        public DbSet<Light> Lights { get; set; } = null!;
        public DbSet<Rack> Racks { get; set; } = null!;
        public DbSet<Landscape> Landscapes { get; set; } = null!;
        public DbSet<Decoration> Decorations { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
